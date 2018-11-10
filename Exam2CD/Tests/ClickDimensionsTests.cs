using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2CD.Tests
{
    [TestFixture]
    public class ClickDimensionsTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Initiate()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void ClickDimensions_CentralAmerica()
        {

        }

        [Test]
        public void ClickDimensions_Academy()
        {

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
