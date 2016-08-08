using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace Patterns
{
    [TestClass]
    public class BingTests
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            this.Driver = new FirefoxDriver();
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));
        }

        [TestCleanup]
        public void TeardownTest()
        {
            this.Driver.Quit();
        }

        [TestMethod]
        public void SearchTextInBing()
        {
            BingMainPage bingPage = new BingMainPage(this.Driver);
            bingPage.Navigate();
            bingPage.Search("Automate Planet");
            bingPage.ValidateResultCount("411,000 RESULTS");
        }

    }
}
