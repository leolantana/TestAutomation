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
    public class DataAcquisition_API_Tests
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
        #region Data Acquisition > Auth Config
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTCreateRole()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_GET_AuthSettingsByFacility_ConfigType();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_CreateAuthSettingsForFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_POST_CreateAuthSettingsForFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_UpdateAuthSettingsForFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_PUT_UpdateAuthSettingsForFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_Delete_AuthSettingsForFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_Delete_AuthSettingsForFacility();
        }
        #endregion
        #region Data Acquisition > ConnectionValidation
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_ConnectionValidation()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_GET_ConnectionValidation();
        }
        #endregion
        #region Data Acquisition > Query Config
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_FHIRQueryConfigByFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_GET_FHIRQueryConfigByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_FHIRQueryConfigByFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_DELETE_FHIRQueryConfigByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_FHIRQueryConfigByFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_POST_FHIRQueryConfigByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_FHIRQueryConfigByFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_PUT_FHIRQueryConfigByFacility();
        }
        #endregion
        #region Data Acquisition > Query List
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_FHIRQueryListByFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_GET_FHIRQueryListByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_FHIRQueryListByFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_POST_FHIRQueryListByFacility();
        }
        #endregion
        #region Data Acquisition > Query Plan Config
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_QueryPlanByFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_GET_QueryPlanByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_QueryPlanByFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_POST_QueryPlanByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_QueryPlanByFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_PUT_QueryPlanByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_QueryPlanByFacility()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_DELETE_QueryPlanByFacility();
        }
        #endregion
        #region Data Acquisition > Query Result
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_QueryResultsByCorrelationID()
        {
            DataAcquisition_API_Page api = new DataAcquisition_API_Page(testRun);
            api.Verify_GET_QueryResultsByCorrelationID();
        }
        #endregion
    }
}
