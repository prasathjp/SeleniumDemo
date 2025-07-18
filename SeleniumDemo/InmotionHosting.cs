using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace SeleniumDemo
{
    public class InmotionHosting
    {
        public static void Main(string[] args)
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "https://secure1.inmotionhosting.com/index/login";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Visit Support Center Link
            IWebElement lnkSupportCenter = chromeDriver.FindElement(By.XPath("//span[@class='subnav-title'][text()=' Visit Our Support Center']"));
            lnkSupportCenter.Click();

            ReadOnlyCollection<string> wndHandles = chromeDriver.WindowHandles;
            string currWndHandle = chromeDriver.CurrentWindowHandle;
            foreach (string wndHandle in wndHandles)
            {
                if (wndHandle != currWndHandle)
                {
                    chromeDriver.SwitchTo().Window(wndHandle);

                    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(chromeDriver);
                    fluentWait.Timeout = TimeSpan.FromSeconds(30);
                    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
                    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

                    //Later Link in JS Popup
                    IWebElement lnkLater = fluentWait.Until(dom => dom.FindElement(By.Id("onesignal-slidedown-cancel-button")));
                    lnkLater.Click();

                    //Search Textbox
                    IWebElement txtSearch = chromeDriver.FindElement(By.Name("s"));
                    txtSearch.SendKeys("diskspace");

                    //Search Icon Button
                    IWebElement btnSearch = chromeDriver.FindElement(By.XPath("//button[@type='submit']"));
                    btnSearch.Click();

                    //Header Search Text
                    IWebElement headerSearch = chromeDriver.FindElement(By.XPath("//h1[@class='page-title']"));
                    string strSearchTxt = headerSearch.Text;
                    Console.WriteLine("Text fetched from Header after Search performed : " + strSearchTxt);
                }
            }
        }
    }
}