using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading;
using System.Linq;

namespace ZKSync
{
    public class SeleniumHelper
    {
        public static string metamaskPath = String.Concat(Directory.GetCurrentDirectory(), @"\Extensions\patched.crx");

        public static target[] targets =
        {
                new target { selector = "syncswap", url = "https://syncswap.xyz/" },
                new target { selector = "orbiter", url = "https://www.orbiter.finance/?source=Ethereum&dest=zkSync%20Lite" },
                new target{ selector = "portal_zksync", url = "https://portal.zksync.io/bridge" },
                new target { selector = "swap_zksync", url = "https://swap-zksync.spacefi.io/#/swap" },
                new target { selector = "metamask", url = "chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html" }
        };
        public class target
        {
            public string selector { get; set; }
            public string url { get; set; }
        }

        //Chromedriver start general method     Proxy adden nicht vergessen!!!!
        public static ChromeDriver StartChromedriver(int id, string proxy)
        {
            var chromeOptions = new ChromeOptions();

            if (!Directory.Exists((Directory.GetCurrentDirectory() + @"\Chrome\" + id)))
            {
                Directory.CreateDirectory((Directory.GetCurrentDirectory() + @"\Chrome\" + id));
                ZipFile.ExtractToDirectory(@"Meta\Meta.zip", (Directory.GetCurrentDirectory() + @"\Chrome\" + id + @"\Meta"));
            }


            chromeOptions.AddArgument(String.Concat(@"--user-data-dir=", (Directory.GetCurrentDirectory() + @"\Chrome\" + id)));
            chromeOptions.AddArgument(String.Concat(@"--load-extension=", (Directory.GetCurrentDirectory() + @"\Chrome\" + id), @"\Meta"));
            chromeOptions.AddArgument("--profile-directory=Default");

            Random rnd = new Random();
            string size = "1920,1080";

            //Window Size
            chromeOptions.AddArgument("--window-size=" + size);
            chromeOptions.AddArgument("--disable-blink-features=FullscreenAllowed");
            chromeOptions.AddArgument("--force-device-scale-factor=1");

            chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
            var chromeDriverService = ChromeDriverService.CreateDefaultService("Chrome");
            chromeDriverService.HideCommandPromptWindow = true;
            chromeDriverService.SuppressInitialDiagnosticInformation = true;
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);

            SetViewportSize(driver, size);

            //pass always on metamask start
            WaitForTwoHandles(driver);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Thread.Sleep(3000);
            if (driver.Url.Contains("#unlock"))
            {
                Profile profile = JsonHelper.profiles[id];
                ExplicitWaitXpath(driver, "//input[@data-testid='unlock-password']", 15);
                driver.FindElement(By.XPath("//input[@data-testid='unlock-password']")).SendKeys(profile.WalletPass);
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//input[@data-testid='unlock-password']")).SendKeys(Keys.Enter);

                try
                {
                    ExplicitWaitXpath(driver, "//div[@class='wallet-overview']", 15);
                }
                catch
                {
                    driver.FindElement(By.XPath("//button[@data-testid='page-container-footer-cancel']")).Click();
                }
                driver.Close();
            }
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            return driver;
        }

        public static void WaitForTwoHandles(ChromeDriver driver)
        {
            while(true)
            {
                Thread.Sleep(50);
                if (driver.WindowHandles.Count >= 2) return;
            }
        }

        public static void QuitChrome(ChromeDriver driver)
        {
            string firstTab = driver.WindowHandles.First();
            foreach (string handle in driver.WindowHandles)
            {
                if (handle != firstTab)
                {
                    driver.SwitchTo().Window(handle);
                    driver.Close();
                }
            }

            // Switch back to the first tab
            driver.SwitchTo().Window(firstTab);

            // Close the browser
            driver.Quit();
        }


        public static void ExplicitWaitXpath(ChromeDriver driver, string xpath, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
        }
        public static void ExplicitWaitId(ChromeDriver driver, string idname, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementExists(By.Id(idname)));
        }
        public static void ExplicitWaitClass(ChromeDriver driver, string classname, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName(classname)));
        }
        
        public static void SetViewportSize(ChromeDriver driver, string size)
        {
            driver.ExecuteCdpCommand("Emulation.setDeviceMetricsOverride", new Dictionary<string, object>
            {
                ["width"] = int.Parse(size.Split(',')[0]),
                ["height"] = int.Parse(size.Split(',')[1]),
                ["deviceScaleFactor"] = 0,
                ["mobile"] = false,
                ["screenWidth"] = int.Parse(size.Split(',')[0]),
                ["screenHeight"] = int.Parse(size.Split(',')[1]),
                ["viewport"] = new Dictionary<string, object>
                {
                    ["x"] = 0,
                    ["y"] = 0,
                    ["width"] = int.Parse(size.Split(',')[0]),
                    ["height"] = int.Parse(size.Split(',')[1]),
                    ["scale"] = 1
                }
            });
        }

        //Chrome Tab selector
        public static void ChromeTabSelector(ChromeDriver driver, string selector)
        {
            foreach (var handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
                if (driver.Url.ToString().ToLower().Contains(selector.ToLower()))
                {
                    return;
                }
            }
            driver.SwitchTo().NewWindow(WindowType.Tab);
            driver.Navigate().GoToUrl(Array.Find(targets, item => item.selector == selector.ToLower()).url);
        }
    }
}