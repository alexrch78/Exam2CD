using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam2CD.Enums;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    class CdFindPartnerPage : BasePage
    {
        private static By PARTNER = By.ClassName("fusion-column-wrapper");

        public CdFindPartnerPage(IWebDriver driver) : base(driver) { }

        internal void GoToRegion(Regions region)
        {
            string regionName = region.ToString().Replace("_", "-");
            string selector = string.Format("a[@data-filter='.{0}']", regionName);
            driver.FindElement(By.CssSelector(selector)).Click();
        }

        internal PartnerSection GetPartnerSectionByPartnerName(string partnerName)
        {
            try
            {
                IReadOnlyCollection<IWebElement> allPartnerSections = driver.FindElements(PARTNER);
                IWebElement relevantPartnerEl = allPartnerSections.Where(ps => ps.GetAttribute("innerText").Contains(partnerName)).First();
                return new PartnerSection(relevantPartnerEl);
            }
            catch
            {
                return null;
            }
        }
    }
}
