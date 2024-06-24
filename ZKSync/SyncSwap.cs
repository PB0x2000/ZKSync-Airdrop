using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace ZKSync
{
    internal class SyncSwap
    {
        public static bool LiquidityProvide(Profile profile)
        {
            if (!CurrentFees.CheckZKSyncFees(3334999, 0.6))
            {
                profile.CurrentState = "Fees too high, will try again later automatically";
                profile.InitTryAgain = MaxFees.FeesTryAgainTimeStamp();
                JsonHelper.profiles[profile.ID] = profile;
                JsonHelper.WriteJson();
                return false;
            }
            
            ChromeDriver driver = SeleniumHelper.StartChromedriver(profile.ID, "proxy");
            //Tab selector
            driver.Navigate().GoToUrl("https://syncswap.xyz/swap");
            Metamask.ChangeNetwork(driver, "zkSync Era Mainnet", profile);
            driver.SwitchTo().Window(driver.WindowHandles[0]);

            SeleniumHelper.ExplicitWaitId(driver, "navi-tool", 15);

            //SyncSwap disable IntroPopup
            try
            {
                if (driver.ExecuteScript("return localStorage.getItem('disableIntroTour')").ToString() != "true")
                {
                    driver.ExecuteScript("localStorage.setItem('disableIntroTour','true')");
                    driver.Navigate().Refresh();
                }
            }
            catch { }




            //Wait and click on connect wallet
            SeleniumHelper.ExplicitWaitId(driver, "navi-tool", 15);
            IWebElement syncswap_chain_and_connect_buttons = driver.FindElement(By.Id("navi-tool"));
            var naviButtons = syncswap_chain_and_connect_buttons.FindElements(By.XPath("//button[@type='button']"));
            if (naviButtons.Count < 4)
            {
                naviButtons[1].Click();
                //SyncSwap wait for connect popup and click metamask
                SeleniumHelper.ExplicitWaitXpath(driver, "//div[@class='fade-in-window window-overlay ']", 15);
                IWebElement syncswap_connect_popup = driver.FindElement(By.XPath("//div[@class='fade-in-window window-overlay ']"));
                syncswap_connect_popup.FindElements(By.XPath("//div[@class='relative flex-center row align pointer']"))[0].Click();
                Thread.Sleep(4000);
            }

            

            //Click Deposit Tab
            SeleniumHelper.ExplicitWaitXpath(driver, "//div[@class='pointer row gap-8 align']", 15);
            IList<IWebElement> syncswap_deposit_liqudity = driver.FindElements(By.XPath("//div[@class='pointer row gap-8 align']"));
            foreach (IWebElement element in syncswap_deposit_liqudity)
            {
                if(element.FindElement(By.TagName("d")).Text == "Deposit")
                {
                    element.Click();
                    break;
                }
            }


            return true;
        }

        public static bool SwapInit(Profile profile)
        {
            return true;
        }
    }
}
