using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using Microsoft.Extensions.Configuration;

namespace Portal_UI.Pages
{
    public class BasePage
    {

        public Browser browser;
        public IWebDriver driver;
        public WebDriverWait driverWait;
        public TestContext testContext;
        public TestRun testRun;
        public string portalURL;
        public string envName;
        public string requestURL;
        public IConfigurationRoot config;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="testRun">Instance of the test run</param>
        public BasePage(TestRun testRun)
        {
            this.testRun = testRun;
            this.browser = testRun.Browser;
            this.driver = browser.Driver;
            this.testContext = testRun.TestContext;
            envName = (string)testContext.Properties["environmentName"];
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            portalURL = (string)testContext.Properties["portalURL"];
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        #region Page Objects
        public string testConsignor = "Partnerships";
        public string todayDate = DateTime.Today.ToString("d");
        public string twoWeeksFromToday = DateTime.Today.AddDays(14).ToString("d");
        public string oneYearInThePast = DateTime.Today.AddDays(-365).ToString("d");

        public IWebElement Input_CompanyName => driver.FindElement(By.Id("companyFilterField-inputEl"));
        public IWebElement Input_ConsignorName => driver.FindElement(By.XPath("//input[@id='companyFilterField-inputEl']"));
        public IWebElement Btn_SubmitFilterResults => driver.FindElement(By.XPath("//span[@id='submitFilters-btnIconEl']"));
        public IWebElement TableRow_FirstGridResult => driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@data-recordindex='0']")));
        public IWebElement HeaderLink_Sales => driver.FindElement(By.XPath("//a[@class='dropdown-toggle'][text()='Sales']"));
        public IWebElement ListItem_Invoices => driver.FindElement(By.XPath("//a[@href='/Sales'][text()='Invoices']"));

        #endregion


        #region Page Functions
        public void jsClick(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        public void SelectConsignor()
        {
            Input_ConsignorName.SendKeys(testConsignor);
        }
        public void SubmitFilterResults()
        {
            Btn_SubmitFilterResults.Click();
            browser.WaitForAjax(2);
        }
        public void VerifyGridResultDisplay()
        {
            browser.WaitForAjax(2);
            testRun.Verify(TestRun.ComparisonType.Equals, true, TableRow_FirstGridResult.Displayed, "No Event Results were Displayed in the Grid");
        }
        #endregion
    }
}
