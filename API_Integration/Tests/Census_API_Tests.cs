using API_Integration.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHelper;

namespace API_Integration.Tests
{
    [TestClass]
    public class Census_API_Tests
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

        #region Census
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETPatientHistoryByFacility()
        {
            Census_API_Page api = new Census_API_Page(testRun);
            api.Verify_GETPatientHistoryByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETAdmittedPatientHistoryByFacility()
        {
            Census_API_Page api = new Census_API_Page(testRun);
            api.Verify_GETAdmittedPatientHistoryByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETCurrentCensusByFacility()
        {
            Census_API_Page api = new Census_API_Page(testRun);
            api.Verify_GETCurrentCensusByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETAllPatientsByFacility()
        {
            Census_API_Page api = new Census_API_Page(testRun);
            api.Verify_GETAllPatientsByFacility();
        }
        #endregion
        #region CensusConfiguration
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTCensusConfiguration()
        {
            Census_API_Page api = new Census_API_Page(testRun);
            api.Verify_POSTCensusConfiguration();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETConfigurationByFacility()
        {
            Census_API_Page api = new Census_API_Page(testRun);
            api.Verify_GETConfigurationByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUTConfigurationByFacility()
        {
            Census_API_Page api = new Census_API_Page(testRun);
            api.Verify_PUTConfigurationByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETEConfigurationByFacility()
        {
            Census_API_Page api = new Census_API_Page(testRun);
            api.Verify_DELETEConfigurationByFacility();
        }
        #endregion
    }
}
    

