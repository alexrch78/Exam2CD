using Exam2CD.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2CD.Helpers
{
    public class WebDriverFacade
    {
        private IWebDriver webDriver = null;


        public WebDriverWait GetWait()
        {
            return new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
        }

        public WebDriverFacade(Browsers browser)
        {
            WebDriverFactory factory = new WebDriverFactory();
            webDriver = factory.CreateInstance(browser);
        }

        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return webDriver.FindElements(by);
        }

        public IWebElement FindElement(By by)
        {
            return webDriver.FindElement(by);
        }

        internal void GoToURL(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public void MaximizeWindow()
        {
            webDriver.Manage().Window.Maximize();
        }

        public void WaitForPageLoaded()
        {
            try
            {
                GetWait().Until(d => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch
            {
                //we don't want to fail test on it;
            }
        }

        public bool ValidatePageExists(string url)
        {
            try
            {
                WaitForPageLoaded();
                SwithTabByUrl(url);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ClickElementWithJS(IWebElement clickElement)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)webDriver;
            executor.ExecuteScript("arguments[0].click();", clickElement);
        }

        public void SwithTabByUrl(string url)
        {
            GetWait().Until(d =>
            {
                foreach (string handle in webDriver.WindowHandles)
                {
                    webDriver.SwitchTo().Window(handle);
                    WaitForPageLoaded();
                    if (webDriver.Url.Contains(url))
                        return true;
                }
                return false;
            });
        }

        internal void Quit()
        {
            webDriver.Quit();
        }
    }
}
