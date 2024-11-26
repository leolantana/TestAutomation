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
    public class LinkAdminBFF_API_Tests
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

        #region Event Generation
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTGeneratePatientEvent()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POSTGeneratePatientEvent();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTGenerateReportScheduledEvent()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POSTGenerateReportScheduledEvent();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTGenerateDataAcquisitionRequestedEvent()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POSTGenerateDataAcquisitionRequestedEvent();
        }
        #endregion
        #region Link Bearer Service
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETGetLinkToken()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETGetLinkToken();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETRefreshSigningKey()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETRefreshSigningKey();
        }
        #endregion
        #region Account > Roles
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTCreateRole()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POSTCreateRole();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_UpdateRole()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUT_UpdateRole();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_Role()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_DELETE_Role();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_UpdateRoleClaims()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUT_UpdateRoleClaims();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_RoleList()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_RoleList();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_RoleByID()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_RoleByID();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_RoleByName()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_RoleByName();
        }
        #endregion
        #region Account > Users
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTCreateUser()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POSTCreateUser();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_ActivateUser()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POST_ActivateUser();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_DeactivateUser()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POST_DeactivateUser();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_UpdateUser()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUT_UpdateUser();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_User()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_DELETE_User();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_RecoverUser()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POST_RecoverUser();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_UpdateUserClaims()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUT_UpdateUserClaims();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_UserByID()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_UserByID();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_UserByEmail()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_UserByEmail();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_FacilityUsers()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_FacilityUsers();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_UsersByRole()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_UsersByRole();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_SearchUsers()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_SearchUsers();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_SearchFacilityUsers()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_SearchFacilityUsers();
        }
        #endregion
        #region Account > Claims
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_Claims()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_Claims();
        }
        #endregion
        #region Audit
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETAudits()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETAudits();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETAuditByID()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETAuditByID();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETAuditsByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETAuditsByFacility();
        }
        #endregion
        #region Census Service
        #region Census > Configuration > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETConfigurationByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETConfigurationByFacility();
        }
        #endregion
        #region Census > Configuration > Commands
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTCensusConfiguration()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POSTCensusConfiguration();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUTConfigurationByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUTConfigurationByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETEConfigurationByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_DELETEConfigurationByFacility();
        }
        #endregion
        #region Census
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETCurrentCensusByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETCurrentCensusByFacility();
        }
        #endregion



        #endregion
        #region Data Acquisition Service
        #region Data Acquisition Service > Query Plan > Commands
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_QueryPlanByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POST_QueryPlanByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_UpdateQueryPlanByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUT_UpdateQueryPlanByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_QueryPlanByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_DELETE_QueryPlanByFacility();
        }
        #endregion
        #region Data Acquisition Service > Query Plan > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_QueryPlanByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_QueryPlanByFacility();
        }
        #endregion
        #region Data Acquisition Service > Query Configuration > Commands
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_FHIRQueryConfigByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POST_FHIRQueryConfigByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_FHIRQueryConfigByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_DELETE_FHIRQueryConfigByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_FHIRQueryConfigByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUT_FHIRQueryConfigByFacility();
        }
        #endregion
        #region Data Acquisition Service > Query Configuration > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_FHIRQueryConfigByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_FHIRQueryConfigByFacility();
        }
        #endregion
        #region Data Acquisition Service > Query List > Commands
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_FHIRQueryListByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POST_FHIRQueryListByFacility();
        }
        #endregion
        #region Data Acquisition Service > Query List > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_FHIRQueryListByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_FHIRQueryListByFacility();
        }
        #endregion
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_ConnectionValidation()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_ConnectionValidation();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_QueryResultsByCorrelationID()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_QueryResultsByCorrelationID();
        }
        #endregion
        #region Measure Evaluation Service
        #region Measure Definition > Commands
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_SingleMeasureDef()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUT_SingleMeasureDef();
        }
        #endregion
        #region Measure Definition > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_AllMeasureDefs()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_AllMeasureDefs();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_SingleMeasureDef()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_SingleMeasureDef();
        }
        #endregion
        #endregion
        #region Normalization Service
        #region Normalization Service > Configuration > Commands
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_NormalizationConfigByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POST_NormalizationConfigByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_NormalizationConfigByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUT_NormalizationConfigByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_NormalizationConfigByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_DELETE_NormalizationConfigByFacility();
        }
        #endregion
        #region Normalization Service > Configuration > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_NormalizationConfigByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_NormalizationConfigByFacility();
        }
        #endregion
        #endregion
        #region Notification Service
        #region Notification Service > Configuration > Commands
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTNotificationConfiguration()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POSTNotificationConfiguration();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUTNotificationConfiguration()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUTNotificationConfiguration();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETEConfigurationByID()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_DELETEConfigurationByID();
        }
        #endregion
        #region Notification Service > Configuration > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETNotificationConfiguration()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETNotificationConfiguration();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETNotificationConfigurationByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETNotificationConfigurationByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETNotificationConfigurationByID()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETNotificationConfigurationByID();
        }
        #endregion
        #region Notifications > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETNotificationByID()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETNotificationByID();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETNotificationsByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETNotificationsByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETNotifications()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETNotifications();
        }
        #endregion
        #endregion
        #region Report Service
        #region Report Service > Configuration > Commands
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_ReportConfig()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POST_ReportConfig();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_ReportConfig()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUT_ReportConfig();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_ReportConfig()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_DELETE_ReportConfig();
        }
        #endregion
        #region Report Service > Configuration > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_ReportConfig()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_ReportConfig();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_ReportConfigByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_ReportConfigByFacility();
        }
        #endregion
        #region Report > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_Bundle_Patient()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_Bundle_Patient();
        }
        #endregion
        #endregion
        #region Tenant Service > Commands
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTFacilities()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POSTFacilities();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUTFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUTFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETEFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_DELETEFacility();
        }
        #endregion
        #region Tenant Service > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETFacilities()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETFacilities();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GETFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GETFacility();
        }
        #endregion
        #region Query Dispatch Service
        #region Query Dispatch Service > Configuration > Commands
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_QueryDispatchByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POST_QueryDispatchByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_QueryDispatchByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUT_QueryDispatchByFacility();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_QueryDispatchConfigByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_DELETE_QueryDispatchConfigByFacility();
        }
        #endregion
        #region Query Dispatch Service > Configuration > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_QueryDispatchByFacility()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_QueryDispatchByFacility();
        }
        #endregion
        #endregion
        #region Submission Service > Configuration > Commands
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_CreateSubmissionConfiguration()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_POST_CreateSubmissionConfiguration();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_UpdateSubmissionConfiguration()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_PUT_UpdateSubmissionConfiguration();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_SubmissionConfiguration()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_DELETE_SubmissionConfiguration();
        }
        #endregion
        #region Submission Service > Configuration > Queries
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_SubmissionConfiguration()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_SubmissionConfiguration();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_FacilitySubmissionConfiguration()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_FacilitySubmissionConfiguration();
        }
        #endregion
        #region Link Admin BFF General
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_User()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_User();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_APIInfo()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            api.Verify_GET_APIInfo();
        }
        #endregion



        [TestMethod]
        [TestCategory("API_E2E")]
        public async Task ValidateStaticFacilityExists()
        {
            LinkAdminBFF_Page api = new LinkAdminBFF_Page(testRun);
            await api.ValidateStaticFacilityExists();
        }
    }
}
