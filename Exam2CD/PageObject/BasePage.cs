using Exam2CD.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Exam2CD.PageObject
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
            SeleniumHelper.WaitForPageLoaded(this.driver);
        }
    }
}