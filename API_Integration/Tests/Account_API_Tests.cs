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
    public class Account_API_Tests
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
        #region Account > Roles
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTCreateRole()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_POSTCreateRole();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_UpdateRole()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_PUT_UpdateRole();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_Role()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_DELETE_Role();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_UpdateRoleClaims()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_PUT_UpdateRoleClaims();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_RoleList()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_GET_RoleList();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_RoleByID()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_GET_RoleByID();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_RoleByName()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_GET_RoleByName();
        }
        #endregion
        #region Account > Users
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POSTCreateUser()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_POSTCreateUser();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_ActivateUser()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_POST_ActivateUser();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_DeactivateUser()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_POST_DeactivateUser();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_UpdateUser()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_PUT_UpdateUser();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_DELETE_User()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_DELETE_User();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_POST_RecoverUser()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_POST_RecoverUser();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_PUT_UpdateUserClaims()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_PUT_UpdateUserClaims();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_UserByID()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_GET_UserByID();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_UserByEmail()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_GET_UserByEmail();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_FacilityUsers()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_GET_FacilityUsers();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_UsersByRole()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_GET_UsersByRole();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_SearchUsers()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_GET_SearchUsers();
        }
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_SearchFacilityUsers()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_GET_SearchFacilityUsers();
        }
        #endregion
        #region Account > Claims
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_Claims()
        {
            Account_API_Page api = new Account_API_Page(testRun);
            api.Verify_GET_Claims();
        }
        #endregion
    }
}
