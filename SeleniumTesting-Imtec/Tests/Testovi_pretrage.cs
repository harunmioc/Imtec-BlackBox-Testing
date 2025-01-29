using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using SeleniumTesting_Imtec.Classes;

namespace SeleniumTesting_Imtec.Tests
{
    public class Testsovi_Pretrage
    {
        private HomePage homePage;


        [SetUp]
        public void Setup()
        {
            var driver = WebDriverSingleton.GetDriver();
            homePage = new HomePage(driver);
        }

        [Test]
        public void Test_Uspjesna_Pretraga_Proizvoda()
        {
            homePage.OpenHomePage();
            homePage.SearchProduct("Laptop");

            // Provjeri da li lista proizvoda sadrži više od 0 elemenata
            int productCount = homePage.GetProductCount();
            Assert.Greater(productCount, 0, "Lista proizvoda je prazna nakon pretrage.");

        }

        [Test]
        public void Test_Pretraga_Proizvod_Ne_Postoji()
        {
            Assert.True(true);

            homePage.OpenHomePage();
            homePage.SearchProduct("XYZ123");

            // Provjeri da li lista proizvoda sadrži više od 0 elemenata
            int productCount = homePage.GetProductCount();
            Assert.AreEqual(productCount, 0, "Lista proizvoda nije prazna nakon pretrage.");
        }

        [Test]
        public void Test_Pretraga_Prazno_Polje()
        {

            Assert.True(true);

            homePage.OpenHomePage();
            homePage.SearchProduct("");

            // Provjeri da li lista proizvoda sadrži više od 0 elemenata
            int productCount = homePage.GetProductCount();
            Assert.AreEqual(productCount, 0, "Lista proizvoda nije prazna nakon pretrage.");
        }

        [TearDown]
        public void CleanUp()
        {
            WebDriverSingleton.QuitDriver();
        }
    }
}