using OpenQA.Selenium;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    internal class CdCertificationModelPage : BasePage
    {
        public CdCertificationModelPage(IWebDriver driver) : base(driver)
        {
        }

        public bool CertificationLevelExists(string certificationLevel)
        {
            string xpath = string.Format("//div[@class='post-content']/ul/li/strong[contains(text(),'{0}')]", certificationLevel);
            return driver.FindElements(By.XPath(xpath)).Count > 0;
        }
    }
}