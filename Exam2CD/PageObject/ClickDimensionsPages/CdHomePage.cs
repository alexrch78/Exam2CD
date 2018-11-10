using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Exam2CD.PageObject.ClickDimensionsPages
{
    class CdHomePage : BasePage
    {
        public CdHomePage(IWebDriver driver) : base(driver)
        {
            headerSection = new HeaderSection(driver);
        }

        public HeaderSection headerSection { get; }
    }
}
