using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeworkUITests
{
    public class AboutText
    {
        private static readonly By aboutTextElement = By.XPath("/html/body/main/div/div/p/span[1]");

        public IWebElement GetAboutText(IWebDriver driver)
        {
            return driver.FindElement(aboutTextElement);
        }
    }
    class AboutPage
    {
        private static String url = "https://about.google/intl/en-GB/";
        private IWebDriver driver;

        public AboutPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void Visit()
        {
            driver.Navigate().GoToUrl(url);
        }
        public String getText()
        {
            return getAbout().GetAboutText(driver).Text;
        }

        private AboutText getAbout()
        {
            return new AboutText();
        }
    }
}
