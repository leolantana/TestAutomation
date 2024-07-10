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
    public class Audit_API_Tests
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

        #region Audit
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETAudits()
        {
            Audit_API_Page api = new Audit_API_Page(testRun);
            api.Verify_GETAudits();
        }

        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETAuditByID()
        {
            Audit_API_Page api = new Audit_API_Page(testRun);
            api.Verify_GETAuditByID();
        }

        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETAuditsByFacility()
        {
            Audit_API_Page api = new Audit_API_Page(testRun);
            api.Verify_GETAuditsByFacility();
        }
        #endregion
    }
}
