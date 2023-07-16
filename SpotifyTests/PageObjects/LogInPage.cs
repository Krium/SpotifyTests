using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace SpotifyTests.PageObjects
{
    internal class LogInPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='login-username']")]
        private IWebElement userNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@id='login-password']")]
        private IWebElement passwordInput;


        [FindsBy(How = How.XPath, Using = "//span[@class='ButtonInner-sc-14ud5tc-0 cJdEzG encore-bright-accent-set']")]
        private IWebElement logInButtonLogInPage;

        [FindsBy(How = How.XPath, Using = "//span[@class='Message-sc-15vkh7g-0 dHbxKh']")]
        private IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = "//p[@class='Type__TypeElement-sc-goli3j-0 gkqrGP sc-bqWxrE iJlXnD']")]
        private IWebElement errorUserNameMessage;

        [FindsBy(How = How.XPath, Using = "//div[@id='password-error']//span[@class='Text-sc-g5kv67-0 jYLjty']")]
        private IWebElement errorPasswordMessage;

        public void ClickOnlogInButtonOnLogInPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(logInButtonLogInPage)).Click();
        }

        public void SetValueToUserNameInput(string value)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(userNameInput)).Clear();
            userNameInput.SendKeys(value);
        }

        public void SetValueToPasswordInput(string value)
        {
            passwordInput.Clear();
            passwordInput.SendKeys(value);
        }
        public void ClearCresentials()
        {
            userNameInput.Clear();
            userNameInput.SendKeys("a");
            userNameInput.SendKeys(Keys.Backspace);
            passwordInput.Clear();
            passwordInput.SendKeys("a");
            passwordInput.SendKeys(Keys.Backspace);
        }

        public string GetErrorMessage()
        {
            return errorMessage.Text;
        }

        public string GetErrorUserNameMessage()
        {
            return errorUserNameMessage.Text;
        }
        public string GetErrorPasswordMessage()
        {
            return errorPasswordMessage.Text;
        }

    }
}
