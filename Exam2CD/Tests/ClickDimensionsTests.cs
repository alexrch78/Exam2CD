﻿using Exam2CD.Helpers;
using Exam2CD.PageObject.ClickDimensionsPages;
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
        private const string baseUrl = "http://clickdimensions.com/";
        CdHomePage homePage;

        [SetUp]
        public void Initiate()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseUrl);
            homePage = new CdHomePage(driver);
        }

        [Test]
        public void ClickDimensions_CentralAmerica()
        {
            string partner = "C-ven Technologies";
            string region = "Central America & Caribbean";

            CdTechnologyPage technologyPage = homePage
                .headerSection
                .GoToOurTechnologyPage();
            CdFindPartnerPage findPartnerPage = technologyPage.GoToFindPartner();
            findPartnerPage.GoToRegion(region);
            Assert.IsTrue(findPartnerPage.PartnerExists(partner), "Partner " + partner + " doesn't exist for region " + region);
            findPartnerPage.ClickOnPartnerLink(partner);
            Assert.IsTrue(SeleniumHelper.ValidatePageExists(PartnerPageTitles[partner]), "Cannot redirect to partner " + partner);
        }

        [Test]
        public void ClickDimensions_Academy()
        {
            List<string> certificationsLevels = new List<string>() { "Fundamentals", "Advanced", "Admin" };

            CdLearningAndSupportPage learningSupportPage = homePage.headerSection.GotoLearningAndSupportPage();
            CdCertificationPage certificationPage = learningSupportPage.ClickOnCertification();
            CdCertificationModelPage certificationModelPage = certificationPage.ClickReadMoreOnCertification();
            foreach (string certificationsLevel in certificationsLevels)
            {
                Assert.IsTrue(certificationModelPage.SertificationLevelExists(certificationsLevel), "Level " + certificationsLevel + " doesn't exist");
            }
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
