using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting_Imtec
{
    internal class ContactFormPage
    {
        private IWebDriver _driver;

        // Lokatori
        private readonly By emailField = By.Name("from");
        private readonly By messageField = By.Name("message");
        private readonly By reCaptchaFrame = By.TagName("iframe"); // Pretpostavlja se da je CAPTCHA u iframe-u.
        private readonly By reCaptchaCheckbox = By.Id("recaptcha-anchor");

        private readonly By submitButton = By.Name("submitMessage");
        public string GetAlertMessage()
        {
            // Koristimo WebDriverWait za eksplicitno čekanje
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            // Čekamo da element sa klasom "col-xs-12 alert alert-success" postane vidljiv
            IWebElement alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("alert-success")));

            return alert.Text;
        }
        // Konstruktor
        public ContactFormPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Metode za interakciju s elementima
        public void EnterEmail(string email)
        {
            // Koristi selektor koji cilja input sa name="from"
            var emailElement = _driver.FindElement(emailField);
            emailElement.SendKeys(email);
        }


        public void EnterMessage(string message)
        {
            var messageElement = _driver.FindElement(messageField);
            messageElement.SendKeys(message);
        }

        public void SolveCaptcha()
        {
            // Čekanje da se iframe za CAPTCHA učita
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement captchaFrame = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("iframe[title='reCAPTCHA']")));

            // Prebacivanje na iframe za CAPTCHA
            _driver.SwitchTo().Frame(captchaFrame);

            // Čekanje da checkbox postane vidljiv i klikabilan
            IWebElement captchaCheckbox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".recaptcha-checkbox-border")));

            // Klik na CAPTCHA checkbox
            captchaCheckbox.Click();

            // Vraćanje na osnovni sadržaj stranice
            _driver.SwitchTo().DefaultContent();
        }


        public void SubmitForm()
        {
            _driver.FindElement(submitButton).Click();
        }

        
    }
}
