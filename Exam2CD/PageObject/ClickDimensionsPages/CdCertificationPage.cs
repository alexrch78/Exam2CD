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

        public CdCertificationPage(IWebDriver driver) : base(driver)
        {
        }

        public CdCertificationModelPage ClickReadMoreOnCertification()
        {
            wait.Until(ExpectedConditions.ElementExists(MORE_ON_CERTIFICATION));
            SeleniumHelper.ClickElementWithJS(driver, driver.FindElement(MORE_ON_CERTIFICATION));
            SeleniumHelper.SwithTabByUrl(driver, CERTIFICATION_MODEL_URL);
            return new CdCertificationModelPage(driver);
        }
    }
}