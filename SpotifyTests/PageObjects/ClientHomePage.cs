using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyTests.PageObjects
{
    internal class ClientHomePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public ClientHomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//button[@class='Button-sc-1dqy6lx-0 fXEXug encore-over-media-set SFgYidQmrqrFEVh65Zrg']")]
        private IWebElement clientButton;

        public string GetClientName()
        {
            return clientButton.GetAttribute("aria-label");
        }
    }
}
