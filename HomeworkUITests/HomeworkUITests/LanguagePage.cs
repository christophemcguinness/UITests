using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeworkUITests
{
    public class SpanishRadioButton
    {
        private static readonly By radiobutton = By.XPath("//*[@id='langtes']/div/span[1]");

        public IWebElement getRadiobutton(IWebDriver driver)
        {
            return driver.FindElement(radiobutton);
        }
    }

    public class EnglishRadioButton
    {
        private static readonly By radiobutton = By.XPath("//*[@id='langten']/div/span[1]");

        public IWebElement getRadiobutton(IWebDriver driver)
        {
            return driver.FindElement(radiobutton);
        }
    }

    public class SaveButton
    {
        private static readonly By ButtonElement = By.XPath("/html/body/div[5]/form/div/div[@class='rightPane']/div[@id='Gm4Vke']/div[@id='form-buttons']");
        
        public IWebElement getSaveButton(IWebDriver driver)
        {
            return driver.FindElement(ButtonElement);
        }
    }
    class LanguagePage
    {
        private static String url = "https://www.google.com/preferences?hl=en&prev=https://www.google.com/search?source%3Dhp%26ei%3DTCn0XJbACs37kwXa_JAo%26q%3Ddvsd%26oq%3Ddvsd%26gs_l%3Dpsy-ab.12..0l4j0i131j0l5.18489.18789..18892...0.0..0.146.406.0j3......0....1..gws-wiz.....0.tkS2kH7auOo#languages";
        private IWebDriver driver;

        public LanguagePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void Visit()
        {
            driver.Navigate().GoToUrl(url);
        }
        public void clickRadioButton(String lang)
        {
            if(lang == "Spanish")
            {
                GetSpanishRadioButton().getRadiobutton(driver).Click();
            }
            else
            {
                GetEnglishRadioButton().getRadiobutton(driver).Click();
            }
            
        }

        public void clickSave()
        {
            GetSaveButton().getSaveButton(driver).Submit();
        }

        private SpanishRadioButton GetSpanishRadioButton()
        {
            return new SpanishRadioButton();
        }
        private EnglishRadioButton GetEnglishRadioButton()
        {
            return new EnglishRadioButton();
        }
        private SaveButton GetSaveButton()
        {
            return new SaveButton();
        }
    }
}



