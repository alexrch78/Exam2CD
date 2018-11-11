using Exam2CD.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    internal class CdCertificationPage : BasePage
    {
        private static By MORE_ON_CERTIFICATION = By.XPath("//a[span/text()='Read more about the certification process']");
        private static String CERTIFICATION_MODEL_URL = "introducing-clickdimensions-new-tiered-certification-model";

        public CdCertificationPage(WebDriverFacade driver) : base(driver)
        {
        }

        public CdCertificationModelPage ClickReadMoreOnCertification()
        {
            driver.GetWait().Until(ExpectedConditions.ElementExists(MORE_ON_CERTIFICATION));
            driver.ClickElementWithJS(driver.FindElement(MORE_ON_CERTIFICATION));
            driver.SwithTabByUrl(CERTIFICATION_MODEL_URL);
            return new CdCertificationModelPage(driver);
        }
    }
}