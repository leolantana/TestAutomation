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

namespace API_Integration.Pages
{
    public class BasePage
    {
        public Browser browser;
        public WebDriverWait driverWait;
        public TestContext testContext;
        public TestRun testRun;
        public string apiEnvName;
        public string api_TenantRequestURL;
        public string api_AuditRequestURL;
        public string localhost_Tenant_api_Base;
        public string api_NotificationRequestURL;
        public string api_CensusRequestURL;
        public string api_AccountURL;
        public string api_Account_MOCKServerURL;
        public string api_DataAcquisitionRequestURL;
        public string api_NormalizationRequestURL;
        public string api_QueryDispatchURL;
        public string api_ReportURL;
        public string api_MeasureURL;
        public string api_LinkAdminBffURL;

        public IConfigurationRoot apiconfig;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="testRun">Instance of the test run</param>
        /// 
        public BasePage(TestRun testRun)
        {
            this.testRun = testRun;
            this.browser = testRun.Browser;
            this.testContext = testRun.TestContext;
            apiEnvName = (string)testContext.Properties["apiEnvironmentName"];
            apiconfig = new ConfigurationBuilder().AddJsonFile("apiappsettings.json").Build();
            localhost_Tenant_api_Base = (string)testContext.Properties["localhost_Tenant_api_Base"];
            api_Account_MOCKServerURL = (string)testContext.Properties["api_Account_MOCKServerURL"];
            api_TenantRequestURL = (string)testContext.Properties["api_TenantRequestURL"];
            api_AuditRequestURL = (string)testContext.Properties["api_AuditRequestURL"];
            api_NotificationRequestURL = (string)testContext.Properties["api_NotificationRequestURL"];
            api_CensusRequestURL = (string)testContext.Properties["api_CensusRequestURL"];
            api_AccountURL = (string)testContext.Properties["api_AccountURL"];
            api_DataAcquisitionRequestURL = (string)testContext.Properties["api_DataAcquisitionRequestURL"];
            api_NormalizationRequestURL = (string)testContext.Properties["api_NormalizationRequestURL"];
            api_QueryDispatchURL = (string)testContext.Properties["api_QueryDispatchURL"];
            api_ReportURL = (string)testContext.Properties["api_ReportURL"];
            api_MeasureURL = (string)testContext.Properties["api_MeasureURL"];
            api_LinkAdminBffURL = (string)testContext.Properties["api_LinkAdminBffURL"];
        }
    }
}
