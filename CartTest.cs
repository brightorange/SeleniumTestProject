using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject
{
    [TestFixture]
    public class CartTest
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
        public void testCart()
        {
            driver.Url = "http://localhost/litecart/";
            var ducks = driver.FindElements(By.CssSelector("li.product"));

            for (int i = 0; i < 3; i++)
            {
                ducks[i].Click();
                string quantity = driver.FindElement(By.CssSelector(".quantity")).Text;
                if (driver.FindElements(By.CssSelector("option")).Count > 0)
                {
                    new SelectElement(driver.FindElement(By.Name("options[Size]"))).SelectByText("Small");
                }
                driver.FindElement(By.CssSelector("button[value*=Add]")).Click();
                wait.Until(d => d.FindElement(By.CssSelector(".quantity")).Text != quantity);
                driver.Url = "http://localhost/litecart/";
                ducks = driver.FindElements(By.CssSelector("li.product"));

            }

            driver.FindElement(By.LinkText("Checkout »")).Click();

            while (driver.FindElements(By.CssSelector("td.item")).Count > 0)
            {
                int count = driver.FindElements(By.CssSelector("td.item")).Count;
                driver.FindElement(By.CssSelector("button[value=Remove]")).Click();
                wait.Until(d => d.FindElements(By.CssSelector("td.item")).Count != count);

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