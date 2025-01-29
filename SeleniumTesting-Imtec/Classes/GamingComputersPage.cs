using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting_Imtec.Classes
{
    internal class GamingComputersPage
    {
        private IWebDriver _driver;

        // Lokatori
        private readonly By firstProductImage = By.CssSelector(".item:nth-child(1) .tvproduct-wrapper:nth-child(1) .tvproduct-defult-img");

        // Konstruktor
        public GamingComputersPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Metode za interakciju s elementima
        public void OpenFirstProduct()
        {
            _driver.FindElement(firstProductImage).Click();
        }
    }
}
