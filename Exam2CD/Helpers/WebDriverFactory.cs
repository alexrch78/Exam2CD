using Exam2CD.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2CD.Helpers
{
    public class WebDriverFactory
    {
        public IWebDriver CreateInstance(Browsers browser)
        {
            if (Browsers.Chrome == browser)
            {
                return new ChromeDriver();
            }
            else
            {
                return new FirefoxDriver();
            }
        }
    }
}
