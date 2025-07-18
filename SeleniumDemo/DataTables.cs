using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;

namespace SeleniumDemo
{
    public class DataTables
    {
        private static IWebDriver chromeDriver = null;
        public static void Main(string[] args)
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Url = "https://datatables.net/";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            calcTotEmpSal();
            SelectEmpChkBox("Donna Snider");
        }

        private static void calcTotEmpSal()
        {
            //Pagination Details Div
            IWebElement divPagingInfo = chromeDriver.FindElement(By.Id("example_info"));
            string strPagingInfo = divPagingInfo.Text;
            string[] strArrPagingInfo = strPagingInfo.Split(' ');
            int totRows = 0;
            int perRowCnt = 0;
            int lastRowCnt;
            int totPages;
            for (int i = 0; i < strArrPagingInfo.Length; i++)
            {
                if (strArrPagingInfo[3] != null)
                    perRowCnt = Convert.ToInt32(strArrPagingInfo[3]);
                if (strArrPagingInfo[5] != null)
                    totRows = Convert.ToInt32(strArrPagingInfo[5]);
            }
            totPages = totRows / perRowCnt;
            lastRowCnt = totRows % perRowCnt;
            if (lastRowCnt != 0)
                totPages++;

            //Employee Table
            IWebElement tblEmp = chromeDriver.FindElement(By.Id("example"));
            long totEmpSal = 0;

            /*
            for (int i = 1; i <= totPages; i++)
            {
                if(i == totPages)
                    perRowCnt = lastRowCnt;

                for (int j = 1; j <= perRowCnt; j++)
                {
                    IWebElement tblSalCol = tblEmp.FindElement(By.XPath($"tbody/tr[{j}]/td[4]"));
                    totEmpSal += Convert.ToInt32(tblSalCol.Text.Substring(1));
                }

                //Next Paging Button
                IWebElement btnNextPage = chromeDriver.FindElement(By.XPath("//button[@aria-label='Next']"));
                if (btnNextPage.Enabled == true)
                    btnNextPage.Click();
            }
            */

            perRowCnt = 59;

            for (int i = 1; i <= totPages; i++)
            {
                if (i == totPages)
                {
                    perRowCnt = (lastRowCnt * 6) - 1;
                }

                for (int j = 5; j <= perRowCnt; j = j + 6)
                {
                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)chromeDriver;
                    string strEmpSal = (string)jsExecutor.ExecuteScript($"return document.querySelectorAll(\"#example tbody tr td\")[{j}].innerText");

                    string[] salSplit = strEmpSal.Substring(1).Split(',');
                    string salJoin = String.Join("", salSplit);

                    totEmpSal += Convert.ToInt64(salJoin);
                }

                //Next Paging Button
                IWebElement btnNextPage = chromeDriver.FindElement(By.XPath("//button[@aria-label='Next']"));
                bool isDisabled = Convert.ToBoolean(btnNextPage.GetAttribute("aria-disabled"));
                if (!isDisabled)
                    btnNextPage.Click();
            }
            Console.WriteLine($"Total Salary of all {totRows} Employees : " + totEmpSal);
        }

        private static void SelectEmpChkBox(string empName)
        {
            chromeDriver.Url = "https://datatables.net/extensions/select/examples/checkbox/checkbox.html";

            //Pagination Details Div
            IWebElement divPagingInfo = chromeDriver.FindElement(By.Id("example_info"));
            string strPagingInfo = divPagingInfo.Text;
            string[] strArrPagingInfo = strPagingInfo.Split(' ');
            int totRows = 0;
            int perRowCnt = 0;
            int lastRowCnt;
            int totPages;

            for (int i = 0; i < strArrPagingInfo.Length; i++)
            {
                if (strArrPagingInfo[3] != null)
                    perRowCnt = Convert.ToInt32(strArrPagingInfo[3]);
                if (strArrPagingInfo[5] != null)
                    totRows = Convert.ToInt32(strArrPagingInfo[5]);
            }
            totPages = totRows / perRowCnt;
            lastRowCnt = totRows % perRowCnt;
            if (lastRowCnt != 0)
                totPages++;
            bool loopBreak = false;

            for (int i = 1; i <= totPages; i++)
            {
                //Employee Table Row Data
                ReadOnlyCollection<IWebElement> tblEmpRow = chromeDriver.FindElements(By.XPath("//table[@id='example']/tbody/tr"));
                foreach (IWebElement empRow in tblEmpRow)
                {
                    string currRowEmpName = empRow.FindElement(By.XPath("td[2]")).Text;
                    if (currRowEmpName == empName)
                    {
                        IWebElement empChkBoxCol = empRow.FindElement(By.XPath("td[1]"));
                        empChkBoxCol.Click();
                        loopBreak = true;
                        break;
                    }
                }

                if (loopBreak)
                     break;

                //Next Paging Button
                IWebElement btnNextPage = chromeDriver.FindElement(By.XPath("//button[@aria-label='Next']"));
                if (btnNextPage.Enabled == true)
                    btnNextPage.Click();
            }
        }
    }
}
