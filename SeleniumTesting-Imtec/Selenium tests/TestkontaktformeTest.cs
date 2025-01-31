// Generated by Selenium IDE
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
//[TestFixture]
public class TestkontaktformeTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
 // [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
//  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
 // [Test]
  public void testkontaktforme() {
    driver.Navigate().GoToUrl("https://imtec.ba/");
    driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
    driver.FindElement(By.LinkText("Kontakt forma.")).Click();
    driver.FindElement(By.Name("from")).Click();
    driver.FindElement(By.Name("from")).SendKeys("kabadzic1@etf.unsa.ba");
    driver.FindElement(By.Name("message")).Click();
    driver.FindElement(By.Name("message")).SendKeys("Test za VVS.");
    driver.SwitchTo().Frame(7);
    driver.FindElement(By.CssSelector(".recaptcha-checkbox-border")).Click();
    driver.SwitchTo().DefaultContent();
    driver.FindElement(By.Name("submitMessage")).Click();
    js.ExecuteScript("window.scrollTo(0,258.3999938964844)");
    driver.FindElement(By.CssSelector(".alert")).Click();
  }
}
