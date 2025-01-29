using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting_Imtec.Classes
{
    internal class ProductPage
    {
        private IWebDriver _driver;


        // Lokatori
        private readonly By addToCartButton = By.CssSelector(".product-actions .add-to-cart");
        private readonly By modalMessage = By.CssSelector(".modal-title");
        private readonly By add = By.CssSelector(".tvwishlist-compare-wrapper-page .tv-product-page-add-to-cart-wrapper .add-to-cart");

        // Konstruktor
        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Metode za interakciju s elementima
        public async void AddToCart()
        {
            var element = _driver.FindElement(add);
            Actions actions = new Actions(_driver);

            actions.MoveToElement(element);
            Thread.Sleep(5000);
            

            element.Click();
        }

        public string GetModalMessage()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var modalMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#myModalLabel")));

            return modalMessageElement.Text;
        }
    }
}
