using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Script;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumDemo
{
    public class MalaysianAirlines
    {
        public static void Main(string[] args)
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "https://www.malaysiaairlines.com/";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(chromeDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(30);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));

            //Accept Cookies Button
            bool isAcceptCookiesDisp = fluentWait.Until(doc => chromeDriver.FindElement(By.XPath("//button//span[text()='Accept all cookies']")).Displayed == true);
            IWebElement btnAcceptCookies = chromeDriver.FindElement(By.XPath("//button//span[text()='Accept all cookies']"));
            btnAcceptCookies.Click();

            //From Textbox
            IWebElement txtFrom = chromeDriver.FindElement(By.XPath("//div[@id='book-flight']//input[@aria-label='From']"));
            txtFrom.SendKeys("MAA");

            Actions objAction = new Actions(chromeDriver);
            objAction.SendKeys(Keys.Down).SendKeys(Keys.Enter).SendKeys(Keys.Tab).Perform();

            //To Textbox
            IWebElement txtTo = chromeDriver.FindElement(By.XPath("//div[@id='book-flight']//input[@aria-label='To']"));
            txtTo.SendKeys("SIN");
            objAction.SendKeys(Keys.Tab).Perform();

            DateTime currDate = DateTime.Now;
            string todayDate = currDate.Day <= 9 ? "0" + currDate.Day.ToString() : currDate.Day.ToString();
            string todayMonth = currDate.Month <= 9 ? "0" + currDate.Month.ToString() : currDate.Month.ToString();
            string todayYear = currDate.Year.ToString();
            string fullDate = todayYear + "-" + todayMonth + "-" + todayDate;
            
            //Depart Textbox
            IWebElement btnDeptDate = chromeDriver.FindElement(By.XPath($"//button[@data-date='{fullDate}']"));
            btnDeptDate.Click();

            //One Way Checkbox
            IWebElement chkOneWay = chromeDriver.FindElement(By.XPath("//div[@class='footer-inner']//input[@name='isOneWay']//following-sibling::span"));
            chkOneWay.Click();

            //Done Button
            IWebElement btnDone = chromeDriver.FindElement(By.XPath("//div[@class='footer-inner']//button[@type='button']//following-sibling::span[text()='Done']"));
            btnDone.Click();

            //Find Flight Button
            IWebElement btnFindFlight = chromeDriver.FindElement(By.XPath("//div[@id='book-flight']//button[text()='Find me a flight now']"));
            btnFindFlight.Click();
        }
    }
}