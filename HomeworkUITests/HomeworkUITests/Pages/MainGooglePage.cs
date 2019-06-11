using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeworkUITests
{

    public class MainPageFeelingLuckyButton
    {
        private static readonly By buttonElement = By.XPath("//*[@id='tsf']/div[2]/div/div[3]/center/input[2]");

        public IWebElement GetButtonElement(IWebDriver driver)
        {
            return driver.FindElement(buttonElement);
        }
    }
    public class MainSearchButton
    {
        private static readonly By buttonElement = By.XPath("//*[@id='tsf']/div[2]/div/div[3]/center/input[1]");

        public IWebElement GetMainSearchButton(IWebDriver driver)
        {
            return driver.FindElement(buttonElement);
        }
    }

    public class MainSearchField
    {
        private static readonly By fieldElement = By.XPath("//*[@id='tsf']/div[2]/div/div[1]/div/div[1]/input");

        public IWebElement getSearchField(IWebDriver driver)
        {
            return driver.FindElement(fieldElement);
        }
    }

    public class AboutButton
    {
        private static readonly By buttonElement = By.XPath("//*[@id='hptl']/a[1]");

        public IWebElement GetAboutElement(IWebDriver driver)
        {
            return driver.FindElement(buttonElement);
        }
    }

    public class MainGooglePage
        {
            private static String url = "http://www.google.com/";
            private IWebDriver driver;

            public MainGooglePage(IWebDriver webDriver)
            {
                driver = webDriver;
            }

            public void Visit()
            {
                driver.Navigate().GoToUrl(url);
            }

            public String GetLuckyButtonText()
            {
                return getMainPageFeelingLuckyButton().GetButtonElement(driver).GetAttribute("value");
            }

        public void clickAboutButton()
        {
            GetAboutButton().GetAboutElement(driver).Click();
        }
        public void ClickSearchButton()
        {
            GetMainSearchButton().GetMainSearchButton(driver).Submit();
        }

        public void setSearchText(String text)
            {
               GetMainSearchField().getSearchField(driver).SendKeys(text);
            }

            private MainPageFeelingLuckyButton getMainPageFeelingLuckyButton()
            {
                return new MainPageFeelingLuckyButton();
            }
            private MainSearchField GetMainSearchField()
            {
                return new MainSearchField();
            }

            private AboutButton GetAboutButton()
            {
                return new AboutButton();
            }
            private MainSearchButton GetMainSearchButton()
            {
                return new MainSearchButton();
            }
        }
}
