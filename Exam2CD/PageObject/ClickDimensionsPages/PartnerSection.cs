using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    public class PartnerSection
    {
        private IWebElement rootElement;

        public PartnerSection(IWebElement rootElement)
        {
            this.rootElement = rootElement;
        }

        internal void ClickOnPartnerLink()
        {
            IWebElement clickElement = rootElement.FindElements(By.TagName("a")).Where(el => !el.GetAttribute("href").Contains("clickdimensions")).First();
            clickElement.Click();
            
        }
    }
}
