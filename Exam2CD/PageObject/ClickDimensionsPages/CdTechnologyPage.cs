using Exam2CD.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    internal class CdTechnologyPage : BasePage
    {
        private static By FIND_PARTNER = By.XPath("//a[span/text()='Explore our regional partner directory to find a partner in your area']");

        public CdTechnologyPage(IWebDriver driver) : base(driver)
        {
        }

        public CdFindPartnerPage GoToFindPartner()
        {
            wait.Until(ExpectedConditions.ElementExists(FIND_PARTNER));
            SeleniumHelper.ClickElementWithJS(driver, driver.FindElement(FIND_PARTNER));
            return new CdFindPartnerPage(driver);
        }
    }
}