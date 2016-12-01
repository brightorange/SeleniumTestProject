using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject
{
    [TestFixture]
    public class LabelTest
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
        public void testLabel()
        {
            driver.Url = "http://localhost/litecart/";
            var ducks = driver.FindElements(By.CssSelector("li.product column shadow hover-light"));
            for (int i = 0; i < ducks.Count; i++)
            {
                var label = ducks[i].FindElements(By.CssSelector("div.sticker"));
                Assert.Equals(label.Count, 1);

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