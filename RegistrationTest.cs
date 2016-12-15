using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject
{
    [TestFixture]
    public class RegistrationTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new InternetExplorerDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [Test]
        public void testRegistration()
        {
            driver.Url = "http://localhost/litecart/en/create_account";
            Random rand = new Random();
            string email = rand.Next(1, 10000) + "@mail.ru";
            string password = "123";
            driver.FindElement(By.Name("firstname")).SendKeys("firstname");
            driver.FindElement(By.Name("lastname")).SendKeys("lastname");
            driver.FindElement(By.Name("address1")).SendKeys("address1");
            driver.FindElement(By.Name("postcode")).SendKeys("123456");
            driver.FindElement(By.Name("city")).SendKeys("city");
            driver.FindElement(By.Name("email")).SendKeys(email);
            driver.FindElement(By.Name("phone")).SendKeys("123456");
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.Name("confirmed_password")).SendKeys(password);
            driver.FindElement(By.Name("create_account")).Click();
            driver.FindElement(By.PartialLinkText("Logout")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("email");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(password);



        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}