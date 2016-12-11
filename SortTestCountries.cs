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
    public class SortTestCountries
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
        public void TestSortCountries()

        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            var Countries = driver.FindElements(By.CssSelector("td:not([style ^= text-align]) > a"));
            var countriesText = new List<string>();
            var sortedCountriesText = new List<string>();
            foreach (IWebElement countrie in Countries)
            {
                countriesText.Add(countrie.Text);
                sortedCountriesText.Add(countrie.Text);
            }
            sortedCountriesText.Sort();
            Assert.AreEqual(countriesText, sortedCountriesText);

            Countries = driver.FindElements(By.CssSelector(".row"));
            for (int i = 0; i < Countries.Count; i++)
            {
                if (Int32.Parse(Countries[i].FindElement(By.XPath("td[6]")).Text) > 0)
                {
                    Countries[i].FindElement(By.XPath("td[7]")).Click();
                    var Table = driver.FindElement(By.Id("table-zones"));
                    var Zones = Table.FindElements(By.CssSelector("[name *= zone]"));
                    var ZonesText = new List<string>();
                    var sortedZonesText = new List<string>();
                    foreach (IWebElement zone in Zones)
                    {
                        ZonesText.Add(zone.Text);
                        sortedZonesText.Add(zone.Text);
                    }
                    sortedZonesText.Sort();
                    Assert.AreEqual(ZonesText, sortedZonesText);

                    driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
                    Countries = driver.FindElements(By.CssSelector(".row"));
                }


                
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