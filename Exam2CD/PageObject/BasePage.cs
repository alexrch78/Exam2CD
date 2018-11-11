using Exam2CD.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Exam2CD.PageObject
{
    public class BasePage
    {
        protected WebDriverFacade driver;

        public BasePage(WebDriverFacade driver)
        {
            this.driver = driver;
            driver.WaitForPageLoaded();
        }
    }
}