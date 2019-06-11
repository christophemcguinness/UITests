using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeworkUITests
{
    public class FirstURL
    {
        private static readonly By urlElement = By.XPath("//*[@id='rso']/div[1]/div/div[1]/div/div/div[1]/a/h3");

        public IWebElement GetUrlElement(IWebDriver driver)
        {
            return driver.FindElement(urlElement);
        }
    }

    public class ForthPageText
    {
        private static readonly By TextElement = By.XPath("//*[@id='resultStats']");

        public IWebElement GetTextElement(IWebDriver driver)
        {
            return driver.FindElement(TextElement);
        }
    }

    public class GoogleHomeButton
    {
        private static readonly By imageButtonElement = By.XPath("//*[@id='logo']");

        public IWebElement GetUrlElement(IWebDriver driver)
        {
            return driver.FindElement(imageButtonElement);
        }
    }

    public class HomeHrefText
    {
        private static readonly By HrefText = By.XPath("/html/body[@id='gsr']/div[@id='main']/div[@id='cnt']/div[@id='top_nav']/div/div[@id='hdtb']/div[@id='hdtbSum']/div[@id='hdtb-s']/div[@id='hdtb-msb']/div[1]/div[@id='hdtb-msb-vis']/div[@class='hdtb-mitem hdtb-msel hdtb-imb']");

        public IWebElement GetHrefTextElement(IWebDriver driver)
        {
            return driver.FindElement(HrefText);
        }
    }

    public class ForthPageLink
    {
        private static readonly By ForthLink = By.XPath("//*[@id='nav']/tbody/tr/td[5]/a");

        public IWebElement GetForthPageLinkElement(IWebDriver driver)
        {
            return driver.FindElement(ForthLink);
        }
    }

    public class ToolsElement
    {
        private static readonly By ToolsButtonElement = By.XPath("/html/body[@id='gsr']/div[@id='main']/div[@id='cnt']/div[@id='top_nav']/div/div[@id='hdtb']/div[@id='hdtbSum']/div[@id='hdtb-s']/div[@id='hdtb-msb']/div[2]/a[@id='hdtb-tls']");
        private static readonly By AnyTimeButtonElement = By.XPath("/html/body[@id='gsr']/div[@id='main']/div[@id='cnt']/div[@id='top_nav']/div/div[@id='hdtb']/div[@id='hdtbMenus']/div[@class='hdtb-mn-cont']/div[@class='hdtb-mn-hd'][1]/div[@class='mn-hd-txt']");
        private static readonly By PastHourButtonElement = By.XPath("/html/body[@id='gsr']/div[@id='main']/div[@id='cnt']/div[@id='top_nav']/div/div[@id='hdtb']/div[@id='hdtbMenus']/div[@class='hdtb-mn-cont']/ul[@class='hdtbU hdtb-mn-o']/li[@id='qdr_h']/a[@class='q qs']");
        private static readonly By ElementText = By.XPath("/html/body[@id='gsr']/div[@id='main']/div[@id='cnt']/div[@id='top_nav']/div/div[@id='hdtb']/div[@id='hdtbMenus']/div[@class='hdtb-mn-cont']/div[@class='hdtb-mn-hd hdtb-tsel']/div[@class='mn-hd-txt']");

        public IWebElement GetTextElement(IWebDriver driver)
        {
            return driver.FindElement(ElementText);
        }
        public IWebElement GetToolsElement(IWebDriver driver)
        {
            return driver.FindElement(ToolsButtonElement);
        }
        public IWebElement GetAnyTimeElement(IWebDriver driver)
        {
            return driver.FindElement(AnyTimeButtonElement);
        }
        public IWebElement GetPastHourElement(IWebDriver driver)
        {
            return driver.FindElement(PastHourButtonElement);
        }
    }

    class SearchResultsPage
    {
        private static String url = "https://www.google.com/search?source=hp&ei=-BP0XIrTJsewkwXBtrW4Cg&q=test&oq=test&gs_l=psy-ab.12..0l10.925121.925608..926433...0.0..0.71.267.4......0....1..gws-wiz.....0..0i131.mybNr_xUXtE";
        private IWebDriver driver;

        public SearchResultsPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void Visit()
        {
            driver.Navigate().GoToUrl(url);
        }
        public String GetFirstUrlText()
        {
            return GetFirstUrlElement().GetUrlElement(driver).Text;
        }

        public void ClickURL()
        {
            GetFirstUrlElement().GetUrlElement(driver).Click();
        }

        public void ClickTools()
        {
            GetToolsElementClickable().GetToolsElement(driver).Click();
        }

        public void ClickAnyTime()
        {
            GetToolsElementClickable().GetAnyTimeElement(driver).Click();
        }

        public void ClickHour()
        {
            GetToolsElementClickable().GetPastHourElement(driver).Click();
        }

        public void ClickHome()
        {
            GetHomeButton().GetUrlElement(driver).Click();
        }

        public void ClickForthPageButton()
        {
            GetClickableForthPageButton().GetForthPageLinkElement(driver).Click();
        }

        public string GetTextfromTime()
        {
            return GetToolsElementClickable().GetTextElement(driver).Text;
        }

        public string GetTextfromHomeHref()
        {
            return GetHomeHrefText().GetHrefTextElement(driver).Text;
        }

        public string GetTextfromPageStats()
        {
            return TextForthPage().GetTextElement(driver).Text;
        }

        private FirstURL GetFirstUrlElement()
        {
            return new FirstURL();
        }
        private ToolsElement GetToolsElementClickable()
        {
            return new ToolsElement();
        }
        private HomeHrefText GetHomeHrefText()
        {
            return new HomeHrefText();
        }
        private GoogleHomeButton GetHomeButton()
        {
            return new GoogleHomeButton();
        }
        private ForthPageLink GetClickableForthPageButton()
        {
            return new ForthPageLink();
        }

        private ForthPageText TextForthPage()
        {
            return new ForthPageText();
        }

    }
}
