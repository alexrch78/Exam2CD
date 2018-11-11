using Exam2CD.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    class CdCertificationPage : BasePage
    {
        private static By MORE_ON_CERTIFICATION = By.XPath("//a[span/text()='Read more about the certification process']");
        private static String CERTIFICATION_MODEL_URL = "introducing-clickdimensions-new-tiered-certification-model";

        public CdCertificationPage(IWebDriver driver) : base(driver) { }


        public CdCertificationModelPage ClickReadMoreOnCertification()
        {
            driver.FindElement(MORE_ON_CERTIFICATION).Click();
            SeleniumHelper.SwithTabByUrl(driver, CERTIFICATION_MODEL_URL);
            return new CdCertificationModelPage(driver);
        }
    }
}
