using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace SeleniumDemo
{
    public class Citibank
    {
        public static void Main(string[] args)
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "https://www.online.citibank.co.in/";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Accept Cookies Button
            IWebElement btnAcceptCookies = chromeDriver.FindElement(By.Id("onetrust-accept-btn-handler"));
            btnAcceptCookies.Click();

            //My Account Div
            IWebElement divMyAcc = chromeDriver.FindElement(By.XPath("//div[text()='My Account']"));
            Actions objMouseAction = new Actions(chromeDriver);
            objMouseAction.MoveToElement(divMyAcc).Perform();

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(chromeDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);

            //Banking with Citi link
            IWebElement lnkBankCiti = fluentWait.Until(dom => dom.FindElement(By.XPath("//a[@href='https://www.citi.com']")));
            lnkBankCiti.Click();

            ReadOnlyCollection<string> wndHandles = chromeDriver.WindowHandles;
            string currWndHandle = chromeDriver.CurrentWindowHandle;
            foreach (string wndHandle in wndHandles)
            {
                if (wndHandle != currWndHandle)
                {
                    chromeDriver.SwitchTo().Window(wndHandle);

                    //Username Textbox
                    IWebElement txtUsername = chromeDriver.FindElement(By.Id("username"));
                    txtUsername.SendKeys("john123");

                    //Sign On Button
                    IWebElement btnSignOn = chromeDriver.FindElement(By.Id("signInBtn"));
                    btnSignOn.Click();

                    string strInvalidPwdErrTxt = string.Empty;
                    //Invalid Password Error Span
                    IWebElement spanPwdErr = chromeDriver.FindElement(By.XPath("//span[normalize-space()='Enter a valid password']"));
                    if (spanPwdErr != null)
                    {
                        if (spanPwdErr.Displayed == true && spanPwdErr.Enabled == true)
                            strInvalidPwdErrTxt = spanPwdErr.Text ?? string.Empty;
                    }

                    if (strInvalidPwdErrTxt != string.Empty)
                        Console.WriteLine("Error Message is present : " + strInvalidPwdErrTxt);
                }
            }
        }
    }
}