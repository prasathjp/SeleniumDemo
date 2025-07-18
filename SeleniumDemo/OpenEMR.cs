using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumDemo
{
    public class OpenEMR
    {
        public static void Main(string[] args)
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://demo.openemr.io/b/openemr/";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Username Textbox
            IWebElement txtUsername = chromeDriver.FindElement(By.Id("authUser"));
            txtUsername.SendKeys("admin");

            //Password Textbox
            IWebElement txtPwd = chromeDriver.FindElement(By.Id("clearPass"));
            txtPwd.SendKeys("pass");

            //Language DDL
            IWebElement ddlLang = chromeDriver.FindElement(By.XPath("//select[@name='languageChoice']"));
            SelectElement selLang = new SelectElement(ddlLang);
            selLang.SelectByValue("18");

            //Login Button
            IWebElement btnLogin = chromeDriver.FindElement(By.Id("login-button"));
            btnLogin.Click();

            //Patient Menu Div
            IWebElement divPatientMenu = chromeDriver.FindElement(By.XPath("//div[text()='Patient']"));
            Actions objMouseAction = new Actions(chromeDriver);
            objMouseAction.MoveToElement(divPatientMenu).Perform();

            //New/Search Submenu Div Link under Patient Menu
            IWebElement divNewSearchMenu = chromeDriver.FindElement(By.XPath("//div[text()='New/Search']"));
            divNewSearchMenu.Click();

            //Switching to Search or Add Patient Frame
            chromeDriver.SwitchTo().Frame("pat");

            //Firstname Textbox
            IWebElement txtFname = chromeDriver.FindElement(By.Id("form_fname"));
            txtFname.SendKeys("John");

            //Lastname Textbox
            IWebElement txtLname = chromeDriver.FindElement(By.Id("form_lname"));
            txtLname.SendKeys("Wick");

            //Gender DDL
            IWebElement ddlGender = chromeDriver.FindElement(By.Id("form_sex"));
            SelectElement selGender = new SelectElement(ddlGender);
            selGender.SelectByValue("Male");

            //DOB Textbox
            IWebElement txtDOB = chromeDriver.FindElement(By.Id("form_DOB"));
            txtDOB.SendKeys("2025-07-16");

            //Create Patient Button
            IWebElement btnCreatePatient = chromeDriver.FindElement(By.Id("create"));
            btnCreatePatient.Click();

            chromeDriver.SwitchTo().DefaultContent();
            //Switching to Modal Frame
            chromeDriver.SwitchTo().Frame("modalframe");

            //Confirm Create Patient Button
            IWebElement btnConfirmCreatePatient = chromeDriver.FindElement(By.Id("confirmCreate"));
            btnConfirmCreatePatient.Click();

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(chromeDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoAlertPresentException));

            //Alert Box
            IAlert alertBox = fluentWait.Until(dom => dom.SwitchTo().Alert());
            string alertMessage = alertBox.Text;
            Console.WriteLine("Alert Box Message Content : " + alertMessage);
            alertBox.Accept();

            chromeDriver.SwitchTo().DefaultContent();
            //Happy B'day Div Close Button
            IWebElement divHappyBdayClose = chromeDriver.FindElement(By.ClassName("closeDlgIframe"));
            divHappyBdayClose.Click();

            //Patient Name Span
            IWebElement spanPatientName = chromeDriver.FindElement(By.XPath("//a[@title='To Dashboard']/span"));
            string strPatName = spanPatientName.Text;
            Console.WriteLine("Newly Created Patient Name : " + strPatName);
        }
    }
}