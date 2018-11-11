using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    class CdLearningAndSupportPage : BasePage
    {
        private static By CERTIFICATION = By.XPath("//a[span/text()='ClickDimensions Certification']");

        public CdLearningAndSupportPage(IWebDriver driver) : base(driver) { }

        internal CdCertificationPage ClickOnCertification()
        {
            driver.FindElement(CERTIFICATION).Click();
            return new CdCertificationPage(driver);
        }
    }
}
