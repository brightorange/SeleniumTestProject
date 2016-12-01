using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject
{
    [TestFixture]
    public class MenuTest
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
        public void testMenu()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            var lenMainMenu = driver.FindElements(By.CssSelector("li#app-")).Count;

            for (int i = 0; i < lenMainMenu; i++ )
            {
                var mainMenu = driver.FindElements(By.CssSelector("li#app-"));
                mainMenu[i].Click();
                Assert.IsNotEmpty(driver.FindElements(By.CssSelector("h1")));

                var form = driver.FindElement(By.CssSelector(".selected"));

                var subMenu = form.FindElements(By.CssSelector("span.name"));
                if (subMenu.Count > 1)
                {
                    for (int j = 1; j < subMenu.Count; j++)
                    {
                        subMenu[j].Click();
                        Assert.IsNotEmpty(driver.FindElements(By.CssSelector("h1")));
                        form = driver.FindElement(By.CssSelector(".selected"));
                        subMenu = form.FindElements(By.CssSelector("span.name"));
                    }
                }
                mainMenu = driver.FindElements(By.CssSelector("li#app-"));
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