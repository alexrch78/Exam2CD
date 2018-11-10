using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    class CdTechnologyPage : BasePage
    {
        private static By FIND_PARTNER = By.XPath("//a[span/text()='Explore our regional partner directory to find a partner in your area']");

        public CdTechnologyPage(IWebDriver driver) : base(driver) { }

        public CdFindPartnerPage GoToFindPartner()
        {
            driver.FindElement(FIND_PARTNER).Click();
            return new CdFindPartnerPage(driver);
        }
    }
}
