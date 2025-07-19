using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumDemo
{
    public class RoyalCaribbean
    {
        public static void Main(string[] args)
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "https://www.royalcaribbean.com/";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //SignIn Link
            IWebElement lnkSignIn = chromeDriver.FindElement(By.LinkText("Sign In"));
            lnkSignIn.Click();

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(chromeDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(30);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            //Shadow Roots
            ISearchContext globalLogin = fluentWait.Until(dom => chromeDriver.FindElement(By.CssSelector("global-login")).GetShadowRoot());
            ISearchContext signInForm = globalLogin.FindElement(By.CssSelector("sign-in-form")).GetShadowRoot();
            
            ISearchContext inputText = signInForm.FindElement(By.CssSelector("input-text")).GetShadowRoot();
            //Email Address Textbox
            IWebElement txtEmailAddr = inputText.FindElement(By.CssSelector("#input-text-email"));
            txtEmailAddr.SendKeys("john_wick@gmail.com");

            ISearchContext inputPwd = signInForm.FindElement(By.CssSelector("input-password")).GetShadowRoot();
            //Password Textbox
            IWebElement txtPwd = inputPwd.FindElement(By.CssSelector("#input-password"));
            txtPwd.SendKeys("john123");

            ISearchContext priBtn = signInForm.FindElement(By.CssSelector("primary-button")).GetShadowRoot();
            //Signin Button
            IWebElement btnSingin = priBtn.FindElement(By.CssSelector("button"));
            btnSingin.Click();

            ISearchContext inputErr = signInForm.FindElement(By.CssSelector("input-error")).GetShadowRoot();
            //Error Label
            IWebElement pError = inputErr.FindElement(By.CssSelector("p"));

            Console.WriteLine("Invalid Login Error Message : " + pError.Text);
        }
    }
}