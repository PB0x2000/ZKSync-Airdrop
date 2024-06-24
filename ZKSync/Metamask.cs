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
    internal class Metamask
    {
        public static string[] resolutions = { "1920,1080", "1920,1080", "1536,864", "1280,720", "1440,900", "1600,900", "2560,1440", "1280,1024", "1920,1080" };

        

        //INIT
        public static (string walletPass, string phrase, string walletID, string extensionID) Init(int id, string proxy)
        {
            ChromeDriver driver = SeleniumHelper.StartChromedriver(id, proxy);

            //driver.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#onboarding/welcome");

            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            //Wait and click on create wallet
            SeleniumHelper.ExplicitWaitXpath(driver, "//input[@data-testid='onboarding-terms-checkbox']", 15);
            
            // Get extension id
            string extID = Regex.Match(driver.Url, @"extension:\/\/(.+?)\/").Groups[1].Value;
            
            driver.FindElement(By.XPath("//input[@data-testid='onboarding-terms-checkbox']")).Click();
            
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='onboarding-create-wallet']", 15);
            driver.FindElement(By.XPath("//button[@data-testid='onboarding-create-wallet']")).Click();

            //Wait for "help us improve" and click no thanks
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='metametrics-no-thanks']", 15);
            driver.FindElement(By.XPath("//button[@data-testid='metametrics-no-thanks']")).Click();

            string password = GenerateRandomPassword();

            //Enter password into field 1
            SeleniumHelper.ExplicitWaitXpath(driver, "//input[@data-testid='create-password-new']", 15);
            driver.FindElement(By.XPath("//input[@data-testid='create-password-new']")).SendKeys(password);

            //Enter password into field 2
            SeleniumHelper.ExplicitWaitXpath(driver, "//input[@data-testid='create-password-confirm']", 15);
            driver.FindElement(By.XPath("//input[@data-testid='create-password-confirm']")).SendKeys(password);

            //Click accept cannot recover checkbox
            SeleniumHelper.ExplicitWaitXpath(driver, "//input[@class='check-box far fa-square']", 15);
            driver.FindElement(By.XPath("//input[@class='check-box far fa-square']")).Click();

            //Click "Create a new wallet"
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='create-password-wallet']", 15);
            driver.FindElement(By.XPath("//button[@data-testid='create-password-wallet']")).Click();

            //Click "Secure my wallet (recommended)"
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='secure-wallet-recommended']", 15);
            driver.FindElement(By.XPath("//button[@data-testid='secure-wallet-recommended']")).Click();

            //Click "Reveal Secret Recovery Phrase"
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='recovery-phrase-reveal']", 15);
            driver.FindElement(By.XPath("//button[@data-testid='recovery-phrase-reveal']")).Click();

            //Click "Reveal Secret Recovery Phrase"
            SeleniumHelper.ExplicitWaitXpath(driver, "//div[@data-testid='recovery-phrase-chips']", 15);
            IWebElement phrase_element = driver.FindElement(By.XPath("//div[@data-testid='recovery-phrase-chips']"));

            //Get Phrase
            List<string> phrase = new List<string>();
            foreach (IWebElement element in phrase_element.FindElements(By.XPath("//div[starts-with(@data-testid, 'recovery-phrase-chip-')]")))
            {
                phrase.Add(element.Text);
            }
            
            //Click "Next"
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='recovery-phrase-next']", 15);
            driver.FindElement(By.XPath("//button[@data-testid='recovery-phrase-next']")).Click();

            //Wait till confim phrase page loaded and enter missing words
            SeleniumHelper.ExplicitWaitXpath(driver, "//div[@class='recovery-phrase__footer__confirm']", 15);

            //Confirm Phrase
            foreach (IWebElement element in driver.FindElements(By.XPath("//input[@class='chip__input']")))
            {
                var attribute =
                    (string) driver.ExecuteScript("return arguments[0].getAttribute('data-testid');", element);
                element.SendKeys(phrase[Int32.Parse(attribute.Split('-')[3])]);
            }

            //Click "Confirm"
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='recovery-phrase-confirm']", 15);
            driver.FindElement(By.XPath("//button[@data-testid='recovery-phrase-confirm']")).Click();

            //Click "Got it" finished creation
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='onboarding-complete-done']", 15);
            driver.FindElement(By.XPath("//button[@data-testid='onboarding-complete-done']")).Click();

            //Click "Next" pin extension
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='pin-extension-next']", 15);
            driver.FindElement(By.XPath("//button[@data-testid='pin-extension-next']")).Click();

            //Click "Done" pin extension
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='pin-extension-done']", 15);
            driver.FindElement(By.XPath("//button[@data-testid='pin-extension-done']")).Click();

            //Click away "Whats new"
            //SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='popover-close']", 15);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@data-testid='popover-close']")).Click();

            //Click "Got it" Protect your funds
            try
            {
                SeleniumHelper.ExplicitWaitXpath(driver, "//button[@class='button btn--rounded btn-primary']", 2);
                driver.FindElement(By.XPath("//button[@class='button btn--rounded btn-primary']")).Click();
            }catch{}

            //Add zksyncera mainnet network
            AddNetwork(driver);
            
            //Click three dots to open menu
            SeleniumHelper.ExplicitWaitXpath(driver, "//button[@data-testid='account-options-menu-button']", 15);
            driver.FindElement(By.XPath("//button[@data-testid='account-options-menu-button']")).Click();

            //Get menu and click on show in explorer
            SeleniumHelper.ExplicitWaitXpath(driver, "//div[@data-testid='account-options-menu']", 15);
            IWebElement menu = driver.FindElement(By.XPath("//div[@data-testid='account-options-menu']"));
            menu.FindElements(By.XPath("//button[@class='menu-item']"))[0].Click();

            // Get the current window handle so we can switch back later
            driver.SwitchTo().Window(driver.WindowHandles[1]);


            //Get Addy
            SeleniumHelper.ExplicitWaitXpath(driver, "//span[@id='mainaddress']", 15);
            string walletID = driver.FindElement(By.XPath("//span[@id='mainaddress']")).Text;

            driver.Quit();

            return (password, string.Join(",", phrase), walletID, extID);
        }

        public static string GenerateRandomPassword()
        {
            Random random = new Random();

            // Generate a random password with 8 to 10 characters
            int passwordLength = random.Next(10, 13);

            // Define the character sets to use for the password
            string lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
            string uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string specialCharacters = "!@#$%^&*()_+";

            // Define a string that will hold the password
            string password = "";

            // Add one lowercase letter, one uppercase letter, one number, and one special character to the password
            password += lowercaseLetters[random.Next(lowercaseLetters.Length)];
            password += uppercaseLetters[random.Next(uppercaseLetters.Length)];
            password += numbers[random.Next(numbers.Length)];
            password += specialCharacters[random.Next(specialCharacters.Length)];

            // Add random characters to the password until it reaches the desired length
            while (password.Length < passwordLength)
            {
                // Choose a random character set to use for the next character
                string characterSet = string.Concat(lowercaseLetters, uppercaseLetters, numbers, specialCharacters);
                // Add a random character from the chosen character set to the password
                password += characterSet[random.Next(characterSet.Length)];
            }

            // Shuffle the password characters randomly
            password = new string(password.OrderBy(c => random.Next()).ToArray());

            return password;
        }

        //Enter password if metamask asks
        public static void EnterPassword(ChromeDriver driver, string password)
        {
            try
            {
                SeleniumHelper.ExplicitWaitXpath(driver, "//input[@data-testid='unlock-password']", 8);
                driver.FindElement(By.XPath("//input[@data-testid='unlock-password']")).SendKeys(password);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//button[@data-testid='unlock-submit']")).Click();
            }
            catch { }        
        }

        //Change Network in Metamask
        public static void ChangeNetwork(ChromeDriver driver, string network, Profile profile)
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);

            driver.Navigate().GoToUrl("chrome-extension://" +  profile.ExtensionID + "/home.html#");

            SeleniumHelper.ExplicitWaitXpath(driver, "//div[@data-testid='network-display']", 20);
            string currentNetwork = driver.FindElement(By.XPath("//div[@data-testid='network-display']")).Text;
            
            if(network == currentNetwork) return;
            
            //Click on Networks
            SeleniumHelper.ExplicitWaitXpath(driver, "//div[@data-testid='network-display']", 15);
            driver.FindElement(By.XPath("//div[@data-testid='network-display']")).Click();

            //Click on wanted Network
            SeleniumHelper.ExplicitWaitXpath(driver, "//div[@class='network__add-network-button']", 15);
            IList<IWebElement> metamask_networks = driver.FindElements(By.XPath("//span[@class='network-name-item']"));
            foreach (IWebElement element in metamask_networks)
            {
                if (element.Text == network)
                {
                    element.Click();
                    break;
                }
            }

            //Wait for network change
            SeleniumHelper.ExplicitWaitXpath(driver, "//div[@data-testid='network-display']", 15);
            driver.Close();
        }

        public static void AddNetwork(ChromeDriver driver)
        {
            //Add ZKSYNC Network
            driver.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#settings/networks/add-network");
            SeleniumHelper.ExplicitWaitClass(driver, "networks-tab__add-network-form-body", 15);
            driver.FindElements(By.ClassName("form-field__input"))[0].SendKeys("zkSync Era Mainnet");
            driver.FindElements(By.ClassName("form-field__input"))[1].SendKeys("https://mainnet.era.zksync.io/");
            driver.FindElements(By.ClassName("form-field__input"))[2].SendKeys("324");
            driver.FindElements(By.ClassName("form-field__input"))[3].SendKeys("ETH");
            driver.FindElements(By.ClassName("form-field__input"))[4].SendKeys("https://explorer.zksync.io/");
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//button[@class='button btn--rounded btn-primary']")).Click();
            SeleniumHelper.ExplicitWaitClass(driver, "popover-wrap home__new-network-added", 15);
            driver.FindElement(By.XPath("//button[@class='button btn--rounded btn-secondary']")).Click();
        }
    }
}
