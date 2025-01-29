using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting_Imtec.Classes
{
    internal class CategoryPage
    {
        private IWebDriver _driver;
        private readonly By sortOptionAsc = By.LinkText("Prema cijeni (najjeftiniji - najskuplji)");
        private readonly By sortOptionDesc = By.LinkText("Prema cijeni (nasjkuplji - najjeftiniji )");

        private readonly By price = By.ClassName("price");

        public CategoryPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public void SortByPriceAscending()
        {
            _driver.FindElement(sortOptionAsc).Click();
        }

        public void SortByPriceDescending()
        {
            _driver.FindElement(sortOptionDesc).Click();
        }

        public List<decimal> GetProductPrices()
        {
            var prices = new List<decimal>();
            var priceElements = _driver.FindElements(price);

            foreach (var priceElement in priceElements)
            {
                string priceText = priceElement.Text.Replace("KM", "").Replace(",", "").Trim();
                if (decimal.TryParse(priceText, out decimal price))
                {
                    prices.Add(price);
                    Console.WriteLine(priceText);
                }
            }
            return prices;
        }
    }
}
