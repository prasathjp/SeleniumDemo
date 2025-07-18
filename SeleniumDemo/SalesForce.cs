using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumDemo
{
    public class SalesForce
    {
        public static void Main(string[] args)
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "https://www.salesforce.com/in/form/signup/freetrial-sales/";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //First Name Textbox
            IWebElement txtFname = chromeDriver.FindElement(By.Name("UserFirstName"));
            txtFname.SendKeys("John");

            //Last Name Textbox
            IWebElement txtLname = chromeDriver.FindElement(By.Name("UserLastName"));
            txtLname.SendKeys("Wick");

            //Job Title Textbox
            IWebElement txtTitle = chromeDriver.FindElement(By.Name("UserTitle"));
            txtTitle.SendKeys("IT Manager");

            //Next Link Button
            IWebElement lnkNext = chromeDriver.FindElement(By.XPath("//a[@data-page-cntrl='next']"));
            lnkNext.Click();

            //Employees DDL
            IWebElement ddlEmp = chromeDriver.FindElement(By.Name("CompanyEmployees"));
            SelectElement selEmp = new SelectElement(ddlEmp);
            selEmp.SelectByValue("100");

            //Company Textbox
            IWebElement txtComp = chromeDriver.FindElement(By.Name("CompanyName"));
            txtComp.SendKeys("IT Manager");

            //Country/Region DDL
            IWebElement ddlCtry = chromeDriver.FindElement(By.Name("CompanyCountry"));
            SelectElement selCtry = new SelectElement(ddlCtry);
            selCtry.SelectByValue("GB");

            lnkNext.Click();

            //Email Textbox
            IWebElement txtEmail = chromeDriver.FindElement(By.Name("UserEmail"));
            txtEmail.SendKeys("john@gmail.com");

            //Agree Checkbox
            IWebElement chkAgree = chromeDriver.FindElement(By.XPath("//input[@id='SubscriptionAgreement']//following-sibling::div[@class='checkbox-ui']"));
            chkAgree.Click();

            //Submit Button
            IWebElement btnSubmit = chromeDriver.FindElement(By.XPath("//button[@type='submit']"));
            btnSubmit.Click();

            string strPhNumInvalidErrTxt = string.Empty;
            //Phone Number Error Label
            IWebElement lblPhNumError = chromeDriver.FindElement(By.XPath("//span[contains(@id,'UserPhone')]"));
            if (lblPhNumError != null)
            {
                if (lblPhNumError.Displayed == true && lblPhNumError.Enabled == true)
                    strPhNumInvalidErrTxt = lblPhNumError.Text ?? string.Empty;
            }

            if(strPhNumInvalidErrTxt != string.Empty)
                Console.WriteLine("Error Message is present : " + strPhNumInvalidErrTxt);
        }
    }
}