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
        private WebDriverFacade driver;

        public PartnerSection(WebDriverFacade driver, IWebElement rootElement)
        {
            this.driver = driver;
            this.rootElement = rootElement;
        }

        internal void ClickOnPartnerLink()
        {
            IWebElement clickElement = rootElement.FindElements(By.TagName("a")).Where(el => !el.GetAttribute("href").Contains("clickdimensions")).First();
            driver.ClickElementWithJS(clickElement);
            driver.GetWait().Until(d => d.WindowHandles.Count == 2);
        }
    }
}