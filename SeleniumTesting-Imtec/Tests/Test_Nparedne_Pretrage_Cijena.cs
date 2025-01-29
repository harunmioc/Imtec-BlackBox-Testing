using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTesting_Imtec.Classes;

namespace SeleniumTesting_Imtec.Tests
{
    internal class Test_Nparedne_Pretrage_Cijena
    {
        private SuggestionPage suggestionPage;

        [SetUp]
        public void Setup()
        {
            var driver = WebDriverSingleton.GetDriver();
            suggestionPage = new SuggestionPage(driver);
        }


        [Test]
        public void TestDonjeGraniceCijene()
        {
            suggestionPage.navigateToSuggestionPage();

            // Postavljanje filtera na minimalnu cijenu
            suggestionPage.SetPriceFilterLow("297");

            // Provjera da li postoje proizvodi sa cijenom ispod 297 KM
            bool hasBelowMinimumPrice = suggestionPage.HasProductBelowPrice(297);

            // Validacija
            Assert.IsFalse(hasBelowMinimumPrice, "Na stranici postoji proizvod sa cijenom nižom od 297 KM.");
        }

        [Test]
        public void TestGornjeGraniceCijene()
        {
            suggestionPage.navigateToSuggestionPage();

            // Postavljanje filtera na minimalnu cijenu
            suggestionPage.SetPriceFilterHigh("2000");

            // Provjera da li postoje proizvodi sa cijenom iznad 2000 KM
            bool hasAboveMaximumPrice = suggestionPage.HasProductAbovePrice(2000);

            // Validacija
            Assert.IsFalse(hasAboveMaximumPrice, "Na stranici postoji proizvod sa cijenom većom od 2000 KM.");
        }

    }
}
