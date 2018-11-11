using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    class CdCertificationModelPage : BasePage
    {
        public CdCertificationModelPage(IWebDriver driver) : base(driver) { }

        public bool CertificationLevelExists(string certificationLevel)
        {
            string xpath = string.Format("//div[@class='post-content']/ul/li/strong[text()='{0}']", certificationLevel);
            return driver.FindElements(By.XPath(xpath)).Count > 0;
        }
    }
}
