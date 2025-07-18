using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumDemo
{
    public class Nasscom
    {
        public static void Main(string[] args)
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "https://nasscom.in/";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Login Link Button
            IWebElement lnkLogin = chromeDriver.FindElement(By.Id("myLoginBtn"));
            lnkLogin.Click();

            //Register Link Button
            IWebElement lnkRegister = chromeDriver.FindElement(By.LinkText("REGISTER"));
            lnkRegister.Click();

            //First Name Textbox
            IWebElement txtFname = chromeDriver.FindElement(By.Id("edit-field-fname-reg-0-value"));
            txtFname.SendKeys("admin");

            //Last Name Textbox
            IWebElement txtLname = chromeDriver.FindElement(By.Id("edit-field-lname-0-value"));
            txtLname.SendKeys("pass");

            //Email Address Textbox
            IWebElement txtEmail = chromeDriver.FindElement(By.Id("edit-mail"));
            txtEmail.SendKeys("admin@gmail.com");

            //Company Name Textbox
            IWebElement txtComp = chromeDriver.FindElement(By.Id("edit-field-company-name-registration-0-value"));
            txtComp.SendKeys("Google");

            //Business Focus
            IWebElement ddlBusiFocus = chromeDriver.FindElement(By.Id("edit-field-business-focus-reg"));
            SelectElement selBusiFocus = new SelectElement(ddlBusiFocus);
            selBusiFocus.SelectByText("IT Consulting");

            //Register Button
            IWebElement btnRegister = chromeDriver.FindElement(By.Id("edit-submit"));
            btnRegister.Click();
        }
    }
}