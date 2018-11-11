using OpenQA.Selenium;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    internal class CdHomePage : BasePage
    {
        public CdHomePage(IWebDriver driver) : base(driver)
        {
            headerSection = new HeaderSection(driver);
        }

        public HeaderSection headerSection { get; }
    }
}