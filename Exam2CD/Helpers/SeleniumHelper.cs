using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Exam2CD.Helpers
{
    static class SeleniumHelper
    {
        internal static void WaitForPageLoaded(IWebDriver driver)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(d => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch
            {
                //we don't want to fail test on it;
            }
        }

        internal static bool ValidatePageExists(IWebDriver driver, string url)
        {
            try
            {
                WaitForPageLoaded(driver);
                SwithTabByUrl(driver, url);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static void ClickElementWithJS(IWebDriver driver, IWebElement clickElement)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", clickElement);
        }

        internal static void SwithTabByUrl(IWebDriver driver, string url)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(d =>
            {
                foreach (string handle in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(handle);
                    WaitForPageLoaded(driver);
                    if (driver.Url.Contains(url))
                        return true;
                }
                return false;
            });
        }
    }
}
