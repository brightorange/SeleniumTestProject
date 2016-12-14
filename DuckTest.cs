using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject
{
    [TestFixture]
    public class DuckTest
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
        public void duckPriceTest()
        {
            driver.Url = "http://localhost/litecart/";
            var Duck = driver.FindElement(By.CssSelector("div#box-campaigns"));
            var DuckNameMainPage = Duck.FindElement(By.CssSelector(".name")).Text;
            var DuckRegularPriceMainPage = Duck.FindElement(By.CssSelector(".regular-price")).Text;
            var DuckCampaignPriceMainPage = Duck.FindElement(By.CssSelector(".campaign-price")).Text;
            Duck.FindElement(By.CssSelector("a")).Click();
            var DuckName = driver.FindElement(By.CssSelector("h1.title")).Text;
            var DuckRegularPrice = driver.FindElement(By.CssSelector(".regular-price")).Text;
            var DuckCampaignPrice = driver.FindElement(By.CssSelector(".campaign-price")).Text;
            Assert.AreEqual(DuckNameMainPage, DuckName);
            Assert.AreEqual(DuckRegularPriceMainPage, DuckRegularPrice);
            Assert.AreEqual(DuckCampaignPriceMainPage, DuckCampaignPrice);


        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}