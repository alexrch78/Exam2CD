using Exam2CD.Enums;
using Exam2CD.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    internal class CdFindPartnerPage : BasePage
    {
        private static By PARTNER = By.ClassName("fusion-column-wrapper");

        public CdFindPartnerPage(WebDriverFacade driver) : base(driver)
        {
        }

        internal void GoToRegion(Regions region)
        {
            string regionName = region.ToString().Replace("_", "-");
            string selector = string.Format("a[data-filter='.{0}']", regionName);
            driver.GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector(selector)));
            driver.ClickElementWithJS(driver.FindElement(By.CssSelector(selector)));
        }

        internal PartnerSection GetPartnerSectionByPartnerName(string partnerName)
        {
            try
            {
                IReadOnlyCollection<IWebElement> allPartnerSections = driver.FindElements(PARTNER);
                IWebElement relevantPartnerEl = allPartnerSections.Where(ps => ps.GetAttribute("innerText").Contains(partnerName)).First();
                return new PartnerSection(driver, relevantPartnerEl);
            }
            catch
            {
                return null;
            }
        }
    }
}