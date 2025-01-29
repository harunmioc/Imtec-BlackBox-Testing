using OpenQA.Selenium;
using SeleniumTesting_Imtec.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting_Imtec.Tests
{
    internal class Test_Sorttiranja_Po_Cijeni
    {
        private HomePage homePage;

        [SetUp]
        public void Setup()
        {
            var driver = WebDriverSingleton.GetDriver();
            homePage = new HomePage(driver);
        }


        [Test]
        public void TestSortiranjeMinToMax()
        {
            var driver = WebDriverSingleton.GetDriver();
            var categoryPage = new CategoryPage(driver);
            homePage.OpenHomePage();
            homePage.NavigateToGamingComputers();

            categoryPage.SortByPriceAscending();

            // Dohvatanje cijena proizvoda
            var prices = categoryPage.GetProductPrices();

            // Validacija sortiranja
            var sortedPrices = new List<decimal>(prices);
            sortedPrices.Sort();

            Assert.AreEqual(sortedPrices, prices, "Proizvodi nisu pravilno sortirani od najjeftinijeg prema najskupljem.");
        }

        [Test]
        public void TestSortiranjeMaxToMin()
        {
            var driver = WebDriverSingleton.GetDriver();
            var categoryPage = new CategoryPage(driver);
            homePage.OpenHomePage();
            homePage.NavigateToGamingComputers();

            categoryPage.SortByPriceDescending();


            // Dohvatanje cijena proizvoda
            var prices = categoryPage.GetProductPrices();

            // Validacija sortiranja
            var sortedPrices = new List<decimal>(prices);
            sortedPrices.Sort();

            Assert.AreEqual(sortedPrices, prices, "Proizvodi nisu pravilno sortirani od najjeftinijeg prema najskupljem.");
        }

    }
}
