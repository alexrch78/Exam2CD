using Exam2CD.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    internal class CdLearningAndSupportPage : BasePage
    {
        private static By CERTIFICATION = By.XPath("//a[span/text()='ClickDimensions Certification']");

        public CdLearningAndSupportPage(IWebDriver driver) : base(driver)
        {
        }

        internal CdCertificationPage ClickOnCertification()
        {
            wait.Until(ExpectedConditions.ElementExists(CERTIFICATION));
            IWebElement clickElement = driver.FindElement(CERTIFICATION);
            SeleniumHelper.ClickElementWithJS(driver, clickElement);
            return new CdCertificationPage(driver);
        }
    }
}