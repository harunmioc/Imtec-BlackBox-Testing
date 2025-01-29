using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting_Imtec.Classes
{
    internal class LoginPage
    {

        private IWebDriver _driver;

        // Lokatori za elemente na stranici
        private readonly By loginButton = By.CssSelector(".btn-unstyle > span");
        private readonly By userInfoButton = By.CssSelector("li > #tvcmsdesktop-user-info .tvhedaer-sign-span");
        private readonly By emailField = By.Name("email");
        private readonly By passwordField = By.Name("password");
        private readonly By submitButton = By.Id("submit-login");
        private readonly By alertMessage = By.CssSelector(".alert");
        private readonly By odjaviSe = By.ClassName("text-sm-center");
        private readonly By helpBlock = By.ClassName("help-block");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://imtec.ba/");
            _driver.Navigate().GoToUrl("https://imtec.ba/prijava-lscfl?back=my-account");
        }

        public void EnterCredentials(string email, string password)
        {
            _driver.FindElement(emailField).SendKeys(email);
            _driver.FindElement(passwordField).SendKeys(password);
        }

        public void LogOut()
        {
            _driver.Navigate().GoToUrl("https://imtec.ba/?mylogout=");
        }

        public void SubmitLogin()
        {
            _driver.FindElement(submitButton).Click();
        }

        public void HandleAlerts()
        {
            // Čeka da se alert poruka učita i klikne na nju
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            Assert.AreEqual(_driver.FindElement(odjaviSe).Text, "Odjavi se");
           
        }

        public void Handler()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            Assert.AreEqual(_driver.FindElement(helpBlock).Text, "Prijava nije uspjela. Pokušajte opet.");


        }


        public void LoginCorrect(string email, string password)
        {
            NavigateToLoginPage();
            EnterCredentials(email, password);
            SubmitLogin();
            HandleAlerts();
        }
        public void LoginIncorrect(string email, string password)
        {
            NavigateToLoginPage();
            EnterCredentials(email, password);
            SubmitLogin();
            Handler();
        }

    }
}
