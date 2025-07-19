using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumDemo
{
    public class ShadowRootSalesForce
    {
        public static void Main(string[] args)
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "https://www.salesforce.com/form/signup/c/";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(chromeDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            //Shadow Root
            ISearchContext pageBuilder = chromeDriver.FindElement(By.CssSelector("page-builder-miaw-ui[deployment-dev-name='page_builder_miaw_ui']")).GetShadowRoot();
            IWebElement btnMinAgtForce = fluentWait.Until(dom => pageBuilder.FindElement(By.CssSelector("button[aria-label='Minimize Agentforce']")));
            btnMinAgtForce.Click();

            Console.WriteLine("ShadowRoot Element Identified & Clicked");
        }
    }
}