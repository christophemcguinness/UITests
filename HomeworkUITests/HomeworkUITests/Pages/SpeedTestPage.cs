using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

///Faster Faster Faster Faster Faster Faster FASTER!!!!!!
 
namespace HomeworkUITests
{
     public class Footer
    {
        private static readonly By FooterText = By.XPath("//*[@id='container']/footer/div/div/div[6]/p");

        public IWebElement GetFooterText(IWebDriver driver)
        {
            return driver.FindElement(FooterText);
        }
    }

    class SpeedTestPage
    {
        private static String url = "https://www.google.com/search?source=hp&ei=-BP0XIrTJsewkwXBtrW4Cg&q=test&oq=test&gs_l=psy-ab.12..0l10.925121.925608..926433...0.0..0.71.267.4......0....1..gws-wiz.....0..0i131.mybNr_xUXtE";
        private IWebDriver driver;

        public SpeedTestPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void Visit()
        {
            driver.Navigate().GoToUrl(url);
        }

        public string getFooterText()
        {
            return GetFooterElement().GetFooterText(driver).Text;
        }

        private Footer GetFooterElement()
        {
            return new Footer();
        }
    }
}
