using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTesting_Imtec.Classes;

namespace SeleniumTesting_Imtec.Tests
{
    internal class Testovi_Dodavanja_u_Korpu
    {

        private HomePage homePage;
        private GamingComputersPage gamingComputersPage;
        private ProductPage productPage;



        [SetUp]
        public void Setup()
        {
            var driver = WebDriverSingleton.GetDriver();
            homePage = new HomePage(driver);
            gamingComputersPage = new GamingComputersPage(driver);
            productPage = new ProductPage(driver);
        }

        [Test]
        public void testdodavanjaukorpu()
        {

            // Navigacija do kategorije proizvoda
            homePage.OpenGamingPage();

            // Otvaranje prvog proizvoda
            gamingComputersPage.OpenFirstProduct();

            // Dodavanje proizvoda u korpu
            productPage.AddToCart();

            Thread.Sleep(3000);
            // Validacija da je proizvod uspješno dodan
            string modalMessage = productPage.GetModalMessage();
            Assert.AreEqual("Proizvod je uspješno dodan u vašu korpu", modalMessage, "Poruka nije očekivana.");
        }

        [TearDown]
        public void CleanUp()
        {
            WebDriverSingleton.QuitDriver();
        }

    }
}
