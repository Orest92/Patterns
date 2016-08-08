using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Patterns
{
    public class BingMainPage
    {
        private readonly IWebDriver driver;
        private readonly string url =  @"http://www.bing.com/";

        public BingMainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "sb_form_q")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.Id, Using = "sb_form_go")]
        public IWebElement GoButton { get; set; }

        [FindsBy(How = How.Id, Using = "b_tween")]
        public IWebElement ResultCountDiv { get; set; }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void Search(string textToType)
        {
            this.SearchBox.Clear();
            this.SearchBox.SendKeys(textToType);
            this.GoButton.Click();
        }

        public void ValidateResultCount(string expextedCount)
        {
            Assert.IsTrue(this.ResultCountDiv.Text.Equals(expextedCount), "Result container contains different result count. " + this.ResultCountDiv.Text);
        }

    }
}
