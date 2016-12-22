using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject
{
    [TestFixture]
    public class MessagesTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            //ChromeOptions o = new ChromeOptions();
            //o.AddArguments("disable-extensions");
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [Test]
        public void testLogMessages()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.Url = "http://localhost/litecart/admin?app=catalog&doc=catalog&category_id=1";
            var products = driver.FindElements(By.CssSelector(".fa-pencil"));
            for(int i = 0; i < products.Count; i++)
            {
                products[i].Click();
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("button[name = cancel]"))).Click();
                products = driver.FindElements(By.CssSelector(".fa-pencil"));
                Assert.IsEmpty(driver.Manage().Logs.GetLog("browser"));
               
            }


        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}