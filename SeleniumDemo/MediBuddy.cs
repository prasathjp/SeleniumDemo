using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumDemo
{
    public class MediBuddy
    {
        public static void Main(string[] args)
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "https://www.medibuddy.in/";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Login Link Button
            IWebElement lnkLogin = chromeDriver.FindElement(By.LinkText("Login"));
            lnkLogin.Click();

            //Corporate Account Link Button
            IWebElement lnkCorpAcc = chromeDriver.FindElement(By.XPath("//div[contains(text(),'Corporate Account')]"));
            lnkCorpAcc.Click();

            //Learn More Link Button
            IWebElement lnkLearnMore = chromeDriver.FindElement(By.LinkText("Learn More"));
            lnkLearnMore.Click();

            //Skip Link Button
            IWebElement lnkSkip = chromeDriver.FindElement(By.LinkText("skip"));
            lnkSkip.Click();

            //Login Username & Password Link Button
            IWebElement lnkUnamePwd = chromeDriver.FindElement(By.PartialLinkText("Username & Password"));
            lnkUnamePwd.Click();

            //Username Textbox
            IWebElement txtUsername = chromeDriver.FindElement(By.Id("username"));
            txtUsername.SendKeys("john");

            //Proceed Button
            IWebElement btnProceed = chromeDriver.FindElement(By.XPath("//button[text()='Proceed']"));
            btnProceed.Click();

            //Password Textbox
            IWebElement txtPassword = chromeDriver.FindElement(By.Id("password"));
            txtPassword.SendKeys("john123");

            //Show Password Image
            IWebElement imgShowPwd = chromeDriver.FindElement(By.XPath("//img[@alt='hide-password']"));
            imgShowPwd.Click();

            //Submit Button
            IWebElement btnSubmit = chromeDriver.FindElement(By.XPath("//button[@type='submit']"));
            btnSubmit.Click();

            string strInvalidCredentialsErrTxt = string.Empty;
            //Invalid Credentials Error Div
            IWebElement divLoginFailErr = chromeDriver.FindElement(By.XPath("//div[@ng-if='isPasswordWrong']"));
            if (divLoginFailErr != null)
            {
                if (divLoginFailErr.Displayed == true && divLoginFailErr.Enabled == true)
                    strInvalidCredentialsErrTxt = divLoginFailErr.Text ?? string.Empty;
            }

            if (strInvalidCredentialsErrTxt != string.Empty)
                Console.WriteLine("Error Message is present : " + strInvalidCredentialsErrTxt);

        }
    }
}