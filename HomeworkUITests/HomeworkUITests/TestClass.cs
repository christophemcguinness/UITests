// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeworkUITests
{
    [TestFixture]
    public class TestClass

    {

        IWebDriver driver;

        [OneTimeSetUp]
        public void InitDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Quit(); // kill instance of driver
        }



        [Test]
        public void HomePageLoadsSucessfully()
        {
            MainGooglePage page = new MainGooglePage(driver);
            page.Visit();
            string buttonText = page.GetLuckyButtonText();
            Console.WriteLine(buttonText);
            Assert.IsTrue(buttonText.Contains("I'm Feeling Lucky"), buttonText + " doesn't contains 'I'm Feeling Lucky'");

        }

        [Test]
        public void FromHomePageMoveToAbout()
        {
            MainGooglePage page = new MainGooglePage(driver);
            page.Visit();
            page.clickAboutButton();
            AboutPage page2 = new AboutPage(driver);
            String aboutText = page2.getText();
            Assert.IsTrue(aboutText.Contains("organise"), aboutText + " doesn't contains 'organise'");
        }

        [Test]
        public void ConfrimWeCanSearch()
        {
            MainGooglePage page = new MainGooglePage(driver);
            page.Visit();
            page.setSearchText("Test");
            page.ClickSearchButton();
            SearchResultsPage page2 = new SearchResultsPage(driver);
            String topUrlText = page2.GetFirstUrlText();
            Assert.IsTrue(topUrlText.Contains("Speedtest by Ookla - The Global Broadband Speed Test"), topUrlText + " doesn't contains 'Speedtest by Ookla - The Global Broadband Speed Test'");

        }

        [Test]
        public void OpeningFirstPageOnSearch()
        {
            MainGooglePage page = new MainGooglePage(driver);
            page.Visit();
            page.setSearchText("Test");
            page.ClickSearchButton();
            SearchResultsPage page2 = new SearchResultsPage(driver);
            page2.ClickURL();
            SpeedTestPage page3 = new SpeedTestPage(driver);
            String footertext = page3.getFooterText();
            Assert.IsTrue(footertext.Contains("Ookla®, Speedtest®, and Speedtest Intelligence® are among some of the federally registered trademarks of Ookla, LLC and may only be used with explicit written permission. © 2006-2019 Ookla, LLC. All Rights Reserved"), footertext + " doesn't contains 'Ookla®, Speedtest®, and Speedtest Intelligence® are among some of the federally registered trademarks of Ookla, LLC and may only be used with explicit written permission. © 2006-2019 Ookla, LLC. All Rights Reserved'");

        }

        [Test]
        public void ChangeLanguageInSettings()
        {
            LanguagePage page = new LanguagePage(driver);
            page.Visit();
            page.clickRadioButton("Spanish");
            page.clickSave();
            SearchResultsPage page2 = new SearchResultsPage(driver);
            string hrefText = page2.GetTextfromHomeHref();
            Assert.IsTrue(hrefText.Contains("Todo"), hrefText + " doesn't contains 'Todo");
        }

        [Test]
        public void ChangeLanguageInSettingsAndChangeBack()
        {
            LanguagePage page = new LanguagePage(driver);
            page.Visit();
            page.clickRadioButton("Spanish");
            page.clickSave();
            driver.SwitchTo().Alert().Accept();
            SearchResultsPage page2 = new SearchResultsPage(driver);
            page.Visit();
            page.clickRadioButton("English");
            page.clickSave();
            driver.SwitchTo().Alert().Accept();
            string hrefText = page2.GetTextfromHomeHref();
            Assert.IsTrue(hrefText.Contains("All"), hrefText + " doesn't contains 'All");

        }
        [Test]
        public void FromSearchPageChangeToAnHour()
        {
            MainGooglePage page = new MainGooglePage(driver);
            page.Visit();
            page.setSearchText("Test");
            page.ClickSearchButton();
            SearchResultsPage page2 = new SearchResultsPage(driver);
            page2.ClickTools();
            System.Threading.Thread.Sleep(5000);
            page2.ClickAnyTime();
            System.Threading.Thread.Sleep(5000);
            page2.ClickHour();
            string timeText = page2.GetTextfromTime();
            Assert.IsTrue(timeText.Contains("Past hour"), timeText + " doesn't contains 'Past Hour");

            //System.Threading.Thread.Sleep(5000);
        }

        [Test]
        public void FromSearchPageMoveBackToMainPage()
        {
            MainGooglePage page = new MainGooglePage(driver);
            page.Visit();
            page.setSearchText("Test");
            page.ClickSearchButton();
            SearchResultsPage page2 = new SearchResultsPage(driver);
            String topUrlText = page2.GetFirstUrlText();
            Assert.IsTrue(topUrlText.Contains("Speedtest by Ookla - The Global Broadband Speed Test"), topUrlText + " doesn't contains 'Speedtest by Ookla - The Global Broadband Speed Test'");
            page2.ClickHome();
            string buttonText = page.GetLuckyButtonText();
            Console.WriteLine(buttonText);
            Assert.IsTrue(buttonText.Contains("I'm Feeling Lucky"), buttonText + " doesn't contains 'I'm Feeling Lucky'");
        }

        [Test]
        public void TestMovingToForthPageOfResults()
        {
            MainGooglePage page = new MainGooglePage(driver);
            page.Visit();
            page.setSearchText("Test");
            page.ClickSearchButton();
            SearchResultsPage page2 = new SearchResultsPage(driver);
            String topUrlText = page2.GetFirstUrlText();
            Assert.IsTrue(topUrlText.Contains("Speedtest by Ookla - The Global Broadband Speed Test"), topUrlText + " doesn't contains 'Speedtest by Ookla - The Global Broadband Speed Test'");
            page2.ClickForthPageButton();
            String statsText = page2.GetTextfromPageStats();
            Assert.IsTrue(statsText.Contains("4"), statsText + " doesn't contain '4'");

        }

    }
}
