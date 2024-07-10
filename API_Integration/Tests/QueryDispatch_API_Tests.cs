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
    public class QueryDispatch_API_Tests
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
        #region Query Dispatch
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_QueryDispatchByFacility()
        {
            QueryDispatch_API_Page api = new QueryDispatch_API_Page(testRun);
            api.Verify_GET_QueryDispatchByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_QueryDispatchByFacility()
        {
            QueryDispatch_API_Page api = new QueryDispatch_API_Page(testRun);
            api.Verify_PUT_QueryDispatchByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_QueryDispatchByFacility()
        {
            QueryDispatch_API_Page api = new QueryDispatch_API_Page(testRun);
            api.Verify_POST_QueryDispatchByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_QueryDispatchByFacility()
        {
            QueryDispatch_API_Page api = new QueryDispatch_API_Page(testRun);
            api.Verify_DELETE_QueryDispatchByFacility();
        }
        #endregion
    }
}
