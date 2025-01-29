using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumTesting_Imtec.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting_Imtec.Tests
{
    internal class TestLogin
    {

        private LoginPage loginPage;

        [SetUp]
        public void SetUp()
        {
            var driver = WebDriverSingleton.GetDriver();
            loginPage = new LoginPage(driver);
        }

        //tacan password uklonjen iz sigurnosnih razloga

        [Test]
        public void testLogin()
        {
            loginPage.LoginCorrect("hmioc1@etf.unsa.ba", "");
            loginPage.LogOut();
        }
        [Test]

        public void testLogin_wrong_email()
        {
            loginPage.LoginIncorrect("ASD@jahdsgbfbzjhagdfh.com", "");

        }
        [Test]

        public void testLogin_wrong_pass()
        {
            loginPage.LoginIncorrect("hmioc1@etf.unsa.ba", "kwrbgbkhbhwe");

        }
        [Test]

        public void testLogin_both_wrong()
        {
            loginPage.LoginIncorrect("ahsbf@aajshdgbfbkh.ba", "kjsadnljljn");
        }
    }
}
