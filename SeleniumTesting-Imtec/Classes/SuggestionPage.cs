using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting_Imtec.Classes
{
    internal class SuggestionPage
    {
        private By ProductPrices = By.ClassName(".price");
        private IWebDriver _driver;

        // Lokatori
        private readonly By addToCartButton = By.CssSelector(".add-to-cart:nth-child(1)");
        private readonly By modalMessage = By.Id("myModalLabel");

        // Konstruktor
        public SuggestionPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void navigateToSuggestionPage()
        {
            _driver.Navigate().GoToUrl("https://imtec.ba/2430-imtec-preporucuje");
        }



        public void SetPriceFilterLow(string fromPrice)
        {
            // Povećanje vremena čekanja na 10 sekundi
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            // Klik na element sa klasom ".from_display > .suffix"
            var fromDisplayElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".from_display > .suffix")));
            fromDisplayElement.Click();

            // Čekanje da polje sa ID "p_from" postane vidljivo i interaktivno
            var fromPriceInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("p_from")));

            // Unos vrednosti u polje
            fromPriceInput.SendKeys("297");
            fromPriceInput.SendKeys(Keys.Enter);
        }


        public void SetPriceFilterHigh(string fromPrice)
        {
            // Povećanje vremena čekanja na 10 sekundi
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            // Klik na element sa klasom ".from_display > .suffix"
            var fromDisplayElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".to_display > .value")));
            fromDisplayElement.Click();

            // Čekanje da polje sa ID "p_from" postane vidljivo i interaktivno
            var fromPriceInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("p_to")));

            // Unos vrednosti u polje
            fromPriceInput.SendKeys("2000");
            fromPriceInput.SendKeys(Keys.Enter);
        }

        public bool HasProductBelowPrice(decimal minimumPrice)
        {
            // Definišemo kulturu koja koristi zarez za decimale i tačku za hiljade
            var culture = new CultureInfo("hr-HR");  // Koristi hrvatski jezik (koji koristi "," kao decimalni separator)

            // Pronađi sve elemente koji sadrže cenu proizvoda
            var prices = _driver.FindElements(By.CssSelector(".tv-product-price .price"))
                .Select(e => e.Text.Replace("KM", "").Trim())  // Uklanja "KM"
                .Select(text => text.Replace(".", ""))  // Uklanja tačku kao separator hiljada
                .Where(text => decimal.TryParse(text, NumberStyles.Any, culture, out _))  // Proverava da li je tekst validan broj
                .Select(text => decimal.Parse(text, NumberStyles.Any, culture))  // Parsira tekst u decimal sa pravilnim formatiranjem
                .ToList();

            // Ispis svih cena u konzolu
            foreach (var price in prices)
            {
                Console.WriteLine(price.ToString("F2"));  // Ispis sa dva decimala
            }

            // Proveri da li postoji bilo koja cena manja od minimuma
            return prices.Any(price => price < minimumPrice);
        }

        public bool HasProductAbovePrice(decimal minimumPrice)
        {
            // Definišemo kulturu koja koristi zarez za decimale i tačku za hiljade
            var culture = new CultureInfo("hr-HR");  // Koristi hrvatski jezik (koji koristi "," kao decimalni separator)

            // Pronađi sve elemente koji sadrže cenu proizvoda
            var prices = _driver.FindElements(ProductPrices)
                .Select(e => e.Text.Replace("KM", "").Trim())  // Uklanja "KM"
                .Select(text => text.Replace(".", ""))  // Uklanja tačku kao separator hiljada
                .Where(text => decimal.TryParse(text, NumberStyles.Any, culture, out _))  // Proverava da li je tekst validan broj
                .Select(text => decimal.Parse(text, NumberStyles.Any, culture))  // Parsira tekst u decimal sa pravilnim formatiranjem
                .ToList();

            foreach (var price in prices)
            {
                Console.WriteLine(price.ToString("F2"));  // Ispis sa dva decimala
            }

            // Proveri da li postoji bilo koja cena veća od minimuma
            return prices.Any(price => price > minimumPrice);
        }


    }
}
