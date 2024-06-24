using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.IO;

namespace ZKSync
{
    internal class ZigZag
    {
        //Market Object
        private class Market
        {
            [JsonProperty("op")]
            public string Op { get; set; }

            [JsonProperty("args")]
            public Arg[][] Args { get; set; }
        }
        private class Arg
        {
            [JsonProperty("zigzagChainId")]
            public long ZigzagChainId { get; set; }

            [JsonProperty("baseAssetId")]
            public long BaseAssetId { get; set; }

            [JsonProperty("quoteAssetId")]
            public long QuoteAssetId { get; set; }

            [JsonProperty("baseFee")]
            public double BaseFee { get; set; }

            [JsonProperty("quoteFee")]
            public double QuoteFee { get; set; }

            [JsonProperty("TradingViewChart")]
            public string TradingViewChart { get; set; }

            [JsonProperty("pricePrecisionDecimal")]
            public long PricePrecisionDecimal { get; set; }

            [JsonProperty("baseAsset")]
            public EAsset BaseAsset { get; set; }

            [JsonProperty("alias")]
            public string Alias { get; set; }

            [JsonProperty("quoteAsset")]
            public EAsset QuoteAsset { get; set; }
        }
        private class EAsset
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("address")]
            public string Address { get; set; }

            [JsonProperty("symbol")]
            public string Symbol { get; set; }

            [JsonProperty("decimals")]
            public long Decimals { get; set; }

            [JsonProperty("enabledForFees")]
            public bool EnabledForFees { get; set; }

            [JsonProperty("usdPrice")]
            public double UsdPrice { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        //Json Settings
        private static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        //Custom Socket Client
        class CustomSocketClient
        {
            private ClientWebSocket client;

            private string _strAdressEndpoint { get; }
            public string _strNotifyMessage { get; set; }

            public CustomSocketClient(string strAdressEndpoint)
            {
                _strAdressEndpoint = strAdressEndpoint;
                Initialize();
            }

            private void Initialize()
            {
                client = new ClientWebSocket();
                _strNotifyMessage = "notify message";
            }

            public async Task Start()
            {
                await OpenConnection();
            }

            private async Task OpenConnection()
            {
                if (client.State != WebSocketState.Open)
                {
                    await client.ConnectAsync(new Uri(_strAdressEndpoint), CancellationToken.None); //ToDo built in CancellationToken
                }
            }

            public async Task<string> Receive()
            {
                byte[] buffer = new byte[1024];
                WebSocketReceiveResult result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);//ToDo built in CancellationToken

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    return "abort";
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    stream.Write(buffer, 0, result.Count);
                    while (!result.EndOfMessage)
                    {
                        result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);//ToDo built in CancellationToken
                        stream.Write(buffer, 0, result.Count);
                    }

                    stream.Seek(0, SeekOrigin.Begin);
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        string message = reader.ReadToEnd();
                        return message;
                    }
                }
            }

            public async Task Send(string message)
            {
                if (client.State == WebSocketState.Open)
                {
                    byte[] byteContentBuffer = Encoding.UTF8.GetBytes(message);
                    await client.SendAsync(new ArraySegment<byte>(byteContentBuffer), WebSocketMessageType.Text, true, CancellationToken.None); //ToDo built in CancellationToken
                }
            }
        }

        public static bool Init(Profile profile)
        {
            //Check API fees before starting chrome
            if(GetFee() > MaxFees.ZigZagFees)
            {
                profile.CurrentState = "Fees too high, will try again later automatically";
                profile.InitTryAgain = MaxFees.FeesTryAgainTimeStamp();
                JsonHelper.profiles[profile.ID] = profile;
                JsonHelper.WriteJson();

                return false;
            }

            ChromeDriver driver = SeleniumHelper.StartChromedriver(profile.ID, "proxy");

            //Load Page
            driver.Navigate().GoToUrl("https://trade.zigzag.exchange/?market=ETH-USDC&network=zksync");

            //Check if fees too high
            if (FeesToHigh(driver))
            {
                profile.CurrentState = "Fees too high, will try again later automatically";
                profile.InitTryAgain = MaxFees.FeesTryAgainTimeStamp();
                JsonHelper.profiles[profile.ID] = profile;
                JsonHelper.WriteJson();

                driver.Quit();
                return false;
            }

            //Wait for connect wallet and click
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[text() = 'CONNECT WALLET']", 15);
            driver.FindElements(By.XPath("//button[text() = 'CONNECT WALLET']"))[0].Click();

            //Wait for meta connect and click
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[text() = 'MetaMask']", 15);
            driver.FindElements(By.XPath("//button[text() = 'MetaMask']"))[1].Click();

            //Switch to metamask
            Thread.Sleep(3000);
            SeleniumHelper.ChromeTabSelector(driver, "MetaMask");

            //Enter pass
            Metamask.EnterPassword(driver, profile.WalletPass);

            //Sign metamask
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@class='button btn--rounded btn-primary page-container__footer-button']", 15);
            driver.FindElement(By.XPath("//button[@class='button btn--rounded btn-primary page-container__footer-button']")).Click();
            try
            {
                SeleniumHelper.ExplicitWaitXpath(driver, "//button[@class='button btn--rounded btn-primary page-container__footer-button']", 4);
                driver.FindElement(By.XPath("//button[@class='button btn--rounded btn-primary page-container__footer-button']")).Click();
            }
            catch{}

            //Switch back to zigzag
            SeleniumHelper.ChromeTabSelector(driver, "ZigZag");

            //Check if tried to swap before and aborted because of fees
            int SwapStartCount = 0;
            if(profile.ZigZagInit.SwapCount > 0) SwapStartCount = profile.ZigZagInit.SwapCount;

            bool buy = false;
            for (int i = SwapStartCount; i < 30; i++)
            {
                if (FeesToHigh(driver))
                {
                    profile.CurrentState = "Fees too high, will try again later automatically";
                    profile.InitTryAgain = MaxFees.FeesTryAgainTimeStamp();
                    profile.ZigZagInit.SwapCount = SwapStartCount;
                    JsonHelper.profiles[profile.ID] = profile;
                    JsonHelper.WriteJson();

                    driver.Quit();
                    return false;
                }

                //Set swap amount
                SeleniumHelper.ExplicitWaitXpath(driver, "//span[@aria-labelledby='discrete-slider-always']", 15);
                IWebElement element = driver.FindElement(By.XPath("//span[@aria-labelledby='discrete-slider-always']"));
                driver.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", element, "aria-valuenow", 100);

                if (buy)
                {
                    //Wait for buy and click
                    SeleniumHelper.ExplicitWaitXpath(driver, "//div[text() = 'Buy']", 15);
                    driver.FindElements(By.XPath("//div[text() = 'Buy']"))[0].Click();

                    //Wait for buy ETH and click
                    SeleniumHelper.ExplicitWaitXpath(driver, "//button[text() = 'Buy ETH']", 15);
                    driver.FindElement(By.XPath("//button[text() = 'Buy ETH']")).Click();
                }
                else
                {
                    //Wait for sell and click
                    SeleniumHelper.ExplicitWaitXpath(driver, "//div[text() = 'Sell']", 15);
                    driver.FindElements(By.XPath("//div[text() = 'Sell']"))[0].Click();

                    //Wait for sell ETH and click
                    SeleniumHelper.ExplicitWaitXpath(driver, "//button[text() = 'Sell ETH']", 15);
                    driver.FindElement(By.XPath("//button[text() = 'Sell ETH']")).Click();

                    buy = true;
                }
                //wait for order processed
                SeleniumHelper.ExplicitWaitXpath(driver, "//div[contains(text(), 'Open Orders (0)']", 45);

            }

            SeleniumHelper.QuitChrome(driver);
            return true;
        }

        private static bool FeesToHigh(ChromeDriver driver)
        {
            var feeElement = driver.FindElement(By.XPath("//div[contains(text(), '(~$')]"));
            double fees = double.Parse(Regex.Match(feeElement.Text, "(.+?) USDC").Groups[1].Value);
            
            //Check if fees too high
            if (fees > MaxFees.ZigZagFees)
            {
                return true;
            }
            return false;
        }

        //WebSocket send msg
        private static async Task<double> client(string message)
        {
            CustomSocketClient client = new CustomSocketClient("wss://zigzag-exchange.herokuapp.com/");

            await client.Start();

            await client.Send(message);

            Market market = JsonConvert.DeserializeObject<Market>(await client.Receive(), settings);

            return market.Args[0].FirstOrDefault(item => item.TradingViewChart == "ETHUSDC").QuoteFee;
        }

        //Get Fee
        public static double GetFee()
        {
            var taskWebConnect = Task.Run(() => client("{\"op\":\"marketsreq\",\"args\":[1,true]}"));

            taskWebConnect.Wait();

            return taskWebConnect.Result;
        }
    }
}
