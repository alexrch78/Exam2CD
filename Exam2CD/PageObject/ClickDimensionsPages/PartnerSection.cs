using Exam2CD.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    public class PartnerSection
    {
        private IWebElement rootElement;
        private IWebDriver driver;

        public PartnerSection(IWebDriver driver, IWebElement rootElement)
        {
            this.driver = driver;
            this.rootElement = rootElement;
        }

        internal void ClickOnPartnerLink()
        {
            IWebElement clickElement = rootElement.FindElements(By.TagName("a")).Where(el => !el.GetAttribute("href").Contains("clickdimensions")).First();
            SeleniumHelper.ClickElementWithJS(driver, clickElement);
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(d => d.WindowHandles.Count == 2);
        }
    }
}