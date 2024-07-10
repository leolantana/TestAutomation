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
    public class Notification_API_Tests
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

        #region Notification
        [TestMethod]
        [Ignore]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETNotificationInfo()
        {
            Notification_API_Page api = new Notification_API_Page(testRun);
            api.Verify_GETNotificationInfo();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETNotifications()
        {
            Notification_API_Page api = new Notification_API_Page(testRun);
            api.Verify_GETNotifications();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETNotificationByID()
        {
            Notification_API_Page api = new Notification_API_Page(testRun);
            api.Verify_GETNotificationByID();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETNotificationByFacility()
        {
            Notification_API_Page api = new Notification_API_Page(testRun);
            api.Verify_GETNotificationsByFacility();
        }
        #endregion

        #region NotificationConfiguration
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETConfiguration()
        {
            Notification_API_Page api = new Notification_API_Page(testRun);
            api.Verify_GETNotificationConfiguration();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTNotificationConfiguration()
        {
            Notification_API_Page api = new Notification_API_Page(testRun);
            api.Verify_POSTNotificationConfiguration();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUTNotificationConfiguration()
        {
            Notification_API_Page api = new Notification_API_Page(testRun);
            api.Verify_PUTNotificationConfiguration();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETNotificationConfigurationByFacility()
        {
            Notification_API_Page api = new Notification_API_Page(testRun);
            api.Verify_GETNotificationConfigurationByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETNotificationConfigurationByID()
        {
            Notification_API_Page api = new Notification_API_Page(testRun);
            api.Verify_GETNotificationConfigurationByID();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETEConfigurationByID()
        {
            Notification_API_Page api = new Notification_API_Page(testRun);
            api.Verify_DELETEConfigurationByID();
        }
        #endregion
    }
}
