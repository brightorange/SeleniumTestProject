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
    public class SortTestGeoZones
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
        public void TestSortGeoZones()

        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
            var GeoZones = driver.FindElements(By.CssSelector(".fa-pencil"));
            for (int j = 0; j < GeoZones.Count; j++)
            {
               GeoZones[j].Click();
               var GeoZoneCountries = driver.FindElements(By.CssSelector("[name *= zone_code]"));
               var GeoZoneCountriesText = new List<String>();
               var SortedGeoZoneCountriesText = new List<String>();
               for (int k = 0; k < GeoZoneCountries.Count; k++)
               {
                  GeoZoneCountriesText.Add(GeoZoneCountries[k].FindElement(By.CssSelector("[selected]")).Text);
                  SortedGeoZoneCountriesText.Add(GeoZoneCountries[k].FindElement(By.CssSelector("[selected]")).Text);
               }
               SortedGeoZoneCountriesText.Sort();
               Assert.AreEqual(GeoZoneCountriesText, SortedGeoZoneCountriesText);
               driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
               GeoZones = driver.FindElements(By.CssSelector(".fa-pencil"));
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