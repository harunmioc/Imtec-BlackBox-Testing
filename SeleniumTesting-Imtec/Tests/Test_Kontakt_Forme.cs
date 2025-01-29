using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTesting_Imtec.Classes;

namespace SeleniumTesting_Imtec.Tests
{
    internal class Test_Kontakt_Forme
    {

        private HomePage homePage;
        private ContactFormPage contactPage;

        [SetUp]
        public void Setup()
        {
            var driver = WebDriverSingleton.GetDriver();
            homePage = new HomePage(driver);
            contactPage = new ContactFormPage(driver);
        }

        [Test]
        public void testkontaktforme()
        {
            Assert.True(true);
            
            // Otvaranje kontakt forme
            homePage.OpenHomePage();
            homePage.OpenContactForm();

            Thread.Sleep(2000); // Pauza od 2 sekunde

            // Popunjavanje i slanje forme

            contactPage.EnterEmail("hmioc1@etf.unsa.ba");
            Thread.Sleep(2000); // Pauza od 2 sekunde

            contactPage.EnterMessage("Test za VVS.");
            Thread.Sleep(2000); // Pauza od 2 sekunde

            contactPage.SolveCaptcha();
            Thread.Sleep(2000); // Pauza od 2 sekunde

            contactPage.SubmitForm();

            Thread.Sleep(2500);

            // Validacija rezultata
            string alertMessage = contactPage.GetAlertMessage();
            Assert.IsTrue(alertMessage.Contains("Vaša poruka je uspješno poslana"), "Poruka o uspjehu nije prikazana.");
        }

        [TearDown]
        public void CleanUp()
        {
            WebDriverSingleton.QuitDriver();
        }
    }
}
