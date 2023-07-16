using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace SpotifyTests.PageObjects
{
    internal class HomePage
    {
             
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public HomePage(IWebDriver driver) {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
            [FindsBy(How = How.XPath, Using = "//span[@class='ButtonInner-sc-14ud5tc-0 bABUvF encore-inverted-light-set']")]
            private IWebElement logInButton;

        public void ClickOnlogInButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(logInButton)).Click();
        }

    }
}
