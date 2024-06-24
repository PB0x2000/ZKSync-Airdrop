using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace ZKSync
{
    public class BridgeZKSyncIO
    {
        public static bool Start(Profile profile)
        {
            //Check fees api before start
            if (!CurrentFees.CheckBridgeFees(MaxFees.BridgingFees))
            {
                profile.CurrentState = "Fees too high, will try again later automatically";
                profile.InitTryAgain = MaxFees.FeesTryAgainTimeStamp();
                JsonHelper.profiles[profile.ID] = profile;
                JsonHelper.WriteJson();
                return false;
            }
            
            ChromeDriver driver = SeleniumHelper.StartChromedriver(profile.ID, "proxy");
            
            //Import wallet
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Url = "https://bridge.zksync.io/";
            
            string extensionUrl = "chrome-extension://" + profile.ExtensionID + "/home.html#";

            try
            {
                //Standard case wait for submit deposit button bridge site
                SeleniumHelper.ExplicitWaitXpath(driver, "//button[@type='submit']", 18);
            }
            catch
            {
                //Wait for connect button if not already logged in
                SeleniumHelper.ExplicitWaitXpath(driver, "//button[@class='login-btn']", 20);
                driver.FindElement(By.XPath("//button[@class='login-btn']")).Click();
                Thread.Sleep(10000);
                //Switch to metamask
                ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                driver.Navigate().GoToUrl(extensionUrl);

                //Enter password
                Metamask.EnterPassword(driver, profile.WalletPass);

                //Click continue
                SeleniumHelper.ExplicitWaitXpath(driver, "//button[@class='button btn--rounded btn-primary']", 30);
                driver.FindElement(By.XPath("//button[@class='button btn--rounded btn-primary']")).Click();

                //Click connect
                SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='page-container-footer-next']", 30);
                driver.FindElement(By.XPath("//button[@data-testid='page-container-footer-next']")).Click();


                driver.SwitchTo().Window(driver.WindowHandles[0]);
            }

            //Click max button
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@class='max-button']", 30);
            Thread.Sleep(12000);
            driver.FindElement(By.XPath("//button[@class='max-button']")).Click();

            //Wait for fees deposit button clickable
            
            //Click deposit button
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@type='submit']", 30);
            Thread.Sleep(3500);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            Thread.Sleep(11000);
            //Switch to Metamask Notification
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Navigate().GoToUrl(extensionUrl);

            //Get estimated fees
            SeleniumHelper.ExplicitWaitClass(driver, "currency-display-component__text", 30);
            string maxFeesText = driver.FindElements(By.ClassName("gas-details-item__currency-container"))[0]
                .FindElement(By.ClassName("currency-display-component__text")).Text.Replace("$", "");
            double maxFees = double.Parse(maxFeesText, CultureInfo.GetCultureInfo("en"));
            
            if (maxFees > MaxFees.ZKSyncFees)
            {
                profile.CurrentState = "Fees too high, will try again later automatically";
                profile.InitTryAgain = MaxFees.FeesTryAgainTimeStamp();
                JsonHelper.profiles[profile.ID] = profile;
                JsonHelper.WriteJson();

                //Click disapprove transaction
                SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='page-container-footer-cancel']", 30);
                driver.FindElement(By.XPath("//button[@data-testid='page-container-footer-cancel']")).Click();
                Thread.Sleep(4000);
                driver.Quit();
                return false;
            }

            //Click approve transaction
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='page-container-footer-next']", 30);
            driver.FindElement(By.XPath("//button[@data-testid='page-container-footer-next']")).Click();
            Thread.Sleep(10);
            SeleniumHelper.QuitChrome(driver);
            return true;
        }
    }
}