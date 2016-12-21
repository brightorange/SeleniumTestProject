using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject
{
    [TestFixture]
    public class ProductPage
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
        public void testProductPage()
        {
            driver.Url = "http://localhost/litecart/";
            var campaigns = driver.FindElement(By.Id("box-campaigns"));
            var duck = campaigns.FindElement(By.CssSelector("li.product"));
            var mainPageDuckName = duck.FindElement(By.CssSelector(".name")).Text;
            var mainPageRegularPrice = duck.FindElement(By.CssSelector(".regular-price")).Text;
            var mainPageDiscountPrice = duck.FindElement(By.CssSelector(".campaign-price")).Text;
            var mainPageRegularPriceColor = duck.FindElement(By.CssSelector(".regular-price")).GetCssValue("color");
            var mainPageDiscountPriceColor = duck.FindElement(By.CssSelector(".campaign-price")).GetCssValue("color");
            var mainPageRegularPriceStyle  = duck.FindElement(By.CssSelector(".regular-price")).TagName;
            var mainPageDiscountPriceStyle = duck.FindElement(By.CssSelector(".campaign-price")).TagName;

            Assert.AreEqual(mainPageRegularPriceColor, "rgba(119, 119, 119, 1)");
            Assert.AreEqual(mainPageDiscountPriceColor, "rgba(204, 0, 0, 1)");
            Assert.AreEqual(mainPageRegularPriceStyle, "s");
            Assert.AreEqual(mainPageDiscountPriceStyle, "strong");

            duck.Click();
            var productPageDuckName = driver.FindElement(By.CssSelector(".title[itemprop = name]")).Text;
            var productPageRegularPrice = driver.FindElement(By.CssSelector(".regular-price")).Text;
            var productPageDiscountPrice = driver.FindElement(By.CssSelector(".campaign-price")).Text;

            Assert.AreEqual(mainPageDuckName, productPageDuckName);
            Assert.AreEqual(mainPageRegularPrice, productPageRegularPrice);
            Assert.AreEqual(mainPageDiscountPrice, productPageDiscountPrice);



        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}