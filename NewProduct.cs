using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace SeleniumTestProject
{
    [TestFixture]
    public class NewProduct
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new InternetExplorerDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TestNewProduct()

        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog";
            driver.FindElement(By.CssSelector(".button:last-child")).Click();
            driver.FindElement(By.CssSelector("input[name=status]")).Click();
            Random rand = new Random();
            String name = "Duck " + rand.Next(1, 1000);
            driver.FindElement(By.CssSelector("input[name*=name]")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[data-name*=Rubber]")).Click();
            driver.FindElement(By.LinkText("Information")).Click();
            new SelectElement(driver.FindElement(By.Name("manufacturer_id"))).SelectByText("ACME Corp.");
            driver.FindElement(By.LinkText("Prices")).Click();
            driver.FindElement(By.Name("purchase_price")).Clear();
            driver.FindElement(By.Name("purchase_price")).SendKeys("10");
            driver.FindElement(By.Name("save")).Click();
            Assert.NotZero( driver.FindElements(By.LinkText(name)).Count );



        }





        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}