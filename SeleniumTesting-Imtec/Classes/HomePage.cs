using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting_Imtec.Classes
{
    internal class HomePage
    {
        private IWebDriver _driver;

        // Lokatori
        private readonly By menuButton = By.CssSelector(".ybc-menu-button-toggle_icon > .icon-bar:nth-child(2)");
        private readonly By categoryArrow = By.CssSelector(".mm_menus_li_tab > .arrow");
        private readonly By gamingComputersLink = By.LinkText("GAMING računari");
        private readonly By searchBox = By.Name("s");
        private readonly By searchButton = By.CssSelector(".tvheader-search-btn > .material-icons");
        private readonly By productList = By.Id("js-product-list");

        // Konstruktor
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Metode za interakciju s elementima
        public void OpenHomePage()
        {
            _driver.Navigate().GoToUrl("https://imtec.ba/");
        }

        public void OpenGamingPage()
        {
            _driver.Navigate().GoToUrl("https://imtec.ba/trazi-lscfl?controller=search&s=imtec+game");
        }

        public void SearchProduct(string productName)
        {
            _driver.FindElement(searchBox).SendKeys(productName);
            _driver.FindElement(searchButton).Click();
        }

        public int GetProductCount()
        {
            // Pronađi sve elemente unutar liste proizvoda
            var products = _driver.FindElements(By.CssSelector("#js-product-list .products")); // Pretpostavlja se da proizvodi imaju klasu 'product-item'
            return products.Count;
        }

        public void NavigateToGamingComputers()
        {
            _driver.FindElement(menuButton).Click();
            _driver.FindElement(categoryArrow).Click();
            _driver.FindElement(gamingComputersLink).Click();
        }

        public void OpenContactForm()
        {
            _driver.FindElement(By.CssSelector(".mm_menus_li:nth-child(5) .mm_menu_content_title")).Click();
        }
    }
}
