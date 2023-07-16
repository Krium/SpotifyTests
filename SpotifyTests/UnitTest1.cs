using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpotifyTests.PageObjects;
using System;
using System.Web;

namespace SpotifyTests
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        readonly string errorMessageUserName = "Укажіть ім’я користувача Spotify або адресу електронної пошти.";
        readonly string errorMessagePassword = "Введіть пароль.";
        readonly string errorMessageLogIn = "Неправильне ім’я користувача або пароль.";
        readonly string userName = "TestTestovych";
        


        [TestInitialize]
        
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://open.spotify.com/");

        }
        
            [TestMethod]
            [DataRow ("valentyn", "12345678")]
       
        public void CheckLogInWithEpmtyCredentials(string username, string password)
        {
                       
            HomePage home_page = new HomePage(driver);
            home_page.ClickOnlogInButton();
                        
            LogInPage logIn_page = new LogInPage(driver);
            logIn_page.SetValueToUserNameInput(username);
            logIn_page.SetValueToPasswordInput(password);
            logIn_page.ClearCresentials();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Assert.AreEqual(errorMessageUserName, logIn_page.GetErrorUserNameMessage());
            Assert.AreEqual(errorMessagePassword, logIn_page.GetErrorPasswordMessage());
        }


        [TestMethod]
        [DataRow("valentyn", "12345678")]
        public void CheckLogInWithWrongCredentials(string username, string password)
        {

            HomePage home_page = new HomePage(driver);
            home_page.ClickOnlogInButton();

            LogInPage logIn_page = new LogInPage(driver);
            logIn_page.SetValueToUserNameInput(username);
            logIn_page.SetValueToPasswordInput(password);
            logIn_page.ClickOnlogInButtonOnLogInPage();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Assert.AreEqual(errorMessageLogIn, logIn_page.GetErrorMessage());
        }

        [TestMethod]
        [DataRow("testtestovych01082022@gmail.com", "Raptor1!")]
        public void CheckLogInWithCorrectCredentials(string username, string password)
        {

            HomePage home_page = new HomePage(driver);
            home_page.ClickOnlogInButton();

            LogInPage logIn_page = new LogInPage(driver);
            logIn_page.SetValueToUserNameInput(username);
            logIn_page.SetValueToPasswordInput(password);
            logIn_page.ClickOnlogInButtonOnLogInPage();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            ClientHomePage clientHomePage = new ClientHomePage(driver);
            Assert.AreEqual(userName, clientHomePage.GetClientName());
        }




        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
