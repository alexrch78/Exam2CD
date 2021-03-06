﻿using Exam2CD.Enums;
using Exam2CD.Helpers;
using Exam2CD.PageObject.ClickDimensionsPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace Exam2CD.Tests
{
    [TestFixture]
    public class ClickDimensionsTests
    {
        private WebDriverFacade driver;
        private const string baseUrl = "http://clickdimensions.com/";
        private CdHomePage homePage;

        private Dictionary<string, string> PartnerPageUrls = new Dictionary<string, string>()
        {
            {"C-ven Technologies","c-ven.com" }
        };

        [SetUp]
        public void Initiate()
        {
            Browsers browser = Browsers.Chrome;
            driver = new WebDriverFacade(browser);
            driver.MaximizeWindow();
            driver.GoToURL(baseUrl);
            homePage = new CdHomePage(driver);
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
                Assert.IsTrue(certificationModelPage.CertificationLevelExists(certificationsLevel), "Level " + certificationsLevel + " doesn't exist");
            }
        }

        [Test]
        public void ClickDimensions_CentralAmerica()
        {
            string partner = "C-ven Technologies";
            Regions region = Regions.central_america_caribbean;

            CdTechnologyPage technologyPage = homePage.headerSection.GoToOurTechnologyPage();
            CdFindPartnerPage findPartnerPage = technologyPage.GoToFindPartner();
            findPartnerPage.GoToRegion(region);
            PartnerSection partnerSection = findPartnerPage.GetPartnerSectionByPartnerName(partner);
            Assert.IsTrue(partnerSection != null, "Partner " + partner + " doesn't exist for region " + region.ToString());
            partnerSection.ClickOnPartnerLink();
            Assert.IsTrue(driver.ValidatePageExists(PartnerPageUrls[partner]), "Cannot redirect to partner " + partner);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}