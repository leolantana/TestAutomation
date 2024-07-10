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
    public class Tenant_API_Tests
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

        #region Tenant
        [TestMethod]
        [Ignore]
        [TestCategory("Localhost_API_Test")]
        public void Verify_TEST_FacilityExists()
        {
            Tenant_API_Page api = new Tenant_API_Page(testRun);
            api.Verify_StaticTestFacilityExists();
        }

        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETFacilities()
        {
            Tenant_API_Page api = new Tenant_API_Page(testRun);
            api.Verify_GETFacilities();
        }

        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTFacilities()
        {
            Tenant_API_Page api = new Tenant_API_Page(testRun);
            api.Verify_POSTFacilities();
        }

        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETFacility()
        {
            Tenant_API_Page api = new Tenant_API_Page(testRun);
            api.Verify_GETFacility();
        }

        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETEFacility()
        {
            Tenant_API_Page api = new Tenant_API_Page(testRun);
            api.Verify_DELETEFacility();
        }

        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUTFacility()
        {
            Tenant_API_Page api = new Tenant_API_Page(testRun);
            api.Verify_PUTFacility();
        }
        #endregion
    }
}