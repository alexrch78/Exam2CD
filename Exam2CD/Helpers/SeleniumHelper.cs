using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exam2CD.Helpers
{
    static class SeleniumHelper
    {
        internal static void WaitForPageLoaded(IWebDriver driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(d => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        internal static bool ValidatePageExists(IWebDriver driver, string url)
        {
            try
            {
                SwithTabByUrl(driver, url);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static void SwithTabByUrl(IWebDriver driver, string url)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(d =>
            {
                foreach (string handle in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(handle);
                    if (driver.Url.Contains(url))
                        return true;
                }
                return false;
            });
        }
    }
}
