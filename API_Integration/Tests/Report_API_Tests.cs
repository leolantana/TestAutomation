using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;
using API_Integration.Pages;

namespace API_Integration.Tests
{
    [TestClass]
    public class Report_API_Tests
    {
        private TestContext testContextInstance;
        private TestRun testRun;
        private Browser browser;

        // variables defined in .runsettings       
        private string envName;
        private string requestURL;

        /// <summary>
        /// Creates an instance of the TestContext
        /// </summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            envName = (string)testContextInstance.Properties["environmentName"];
            requestURL = (string)testContextInstance.Properties["requestURL"];
            testRun = new TestRun(TestContext);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            testRun.CleanUp();
        }
        #region Report
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_Bundle_MeasureReport()
        {
            Report_API_Page api = new Report_API_Page(testRun);
            api.Verify_GET_Bundle_MeasureReport();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_Bundle_Patient()
        {
            Report_API_Page api = new Report_API_Page(testRun);
            api.Verify_GET_Bundle_Patient();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_ReportConfig()
        {
            Report_API_Page api = new Report_API_Page(testRun);
            api.Verify_GET_ReportConfig();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_ReportConfigByFacility()
        {
            Report_API_Page api = new Report_API_Page(testRun);
            api.Verify_GET_ReportConfigByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_ReportConfig()
        {
            Report_API_Page api = new Report_API_Page(testRun);
            api.Verify_POST_ReportConfig();
        }
        #endregion
        #region Report Config
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_ReportConfig()
        {
            Report_API_Page api = new Report_API_Page(testRun);
            api.Verify_PUT_ReportConfig();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_ReportConfig()
        {
            Report_API_Page api = new Report_API_Page(testRun);
            api.Verify_DELETE_ReportConfig();
        }
        #endregion
    }
}
