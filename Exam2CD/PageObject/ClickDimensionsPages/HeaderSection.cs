using Exam2CD.Enums;
using Exam2CD.Helpers;
using OpenQA.Selenium;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    public class HeaderSection : BasePage
    {
        public HeaderSection(WebDriverFacade driver) : base(driver)
        {
        }

        internal CdTechnologyPage GoToOurTechnologyPage()
        {
            GoToCategory(Categories.Solution);
            GoToPage(Pages.Our_Technology);
            return new CdTechnologyPage(driver);
        }

        private void GoToPage(Pages page)
        {
            string xpath = string.Format("//a[span/text()='{0}']", page.ToString().Replace("_", " "));
            driver.FindElement(By.XPath(xpath)).Click();
        }

        private void GoToCategory(Categories category)
        {
            string xpath = string.Format("//a[span/text()='{0}']", category.ToString());
            driver.FindElement(By.XPath(xpath)).Click();
        }

        internal CdLearningAndSupportPage GotoLearningAndSupportPage()
        {
            GoToCategory(Categories.Resources);
            GoToPage(Pages.Learning_and_Support);
            return new CdLearningAndSupportPage(driver);
        }
    }
}