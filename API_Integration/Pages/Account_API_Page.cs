using System;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Configuration;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions;
using RestSharp.Serializers;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace API_Integration.Pages
{
    public class Account_API_Page : BasePage
    {

        public Account_API_Page(TestRun testRun) : base(testRun)
        {
            this.testRun = testRun;
        }

        #region Account > Roles > Commands > POST_CreateRole
        public void Verify_POSTCreateRole()
        {
            var apiEndpoint = "api/account/role";
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Roles > Commands > PUT_UpdateRole
        public void Verify_PUT_UpdateRole()
        {
            var testRole = "7f318e89-b040-492f-945f-1c7868a0bade";
            var apiEndpoint = ($"api/account/role/{testRole}");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Roles > Commands > DELETE_Role
        public void Verify_DELETE_Role()
        {
            var testRole = "1afd9f07-9330-4635-9eee-3231f9d657f8";
            var apiEndpoint = ($"api/account/role/{testRole}");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();

            try
            {
                var response = client.Delete(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                var responseDesc = ex.Message;
                testRun.Verify(TestRun.ComparisonType.Contains, responseDesc, "Request failed with status code Unauthorized", "Authorization required as expected");
            }
        }
        #endregion
        #region Account > Roles > Commands > UPDATE_RoleClaims
        public void Verify_PUT_UpdateRoleClaims()
        {
            var testRole = "de2b4f93-2e0f-4801-8095-e9c791df9035";
            var apiEndpoint = ($"api/account/role/{testRole}/claims");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Roles > Queries > GET_RoleList
        public void Verify_GET_RoleList()
        {
            var apiEndpoint = "api/account/role";
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Roles > Queries > GET_RoleByID
        public void Verify_GET_RoleByID()
        {
            var testRole = "1afd9f07-9330-4635-9eee-3231f9d657f8";
            var apiEndpoint = ($"api/account/role/{testRole}");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Roles > Queries > GET_RoleByName
        public void Verify_GET_RoleByName()
        {
            var testRole = "LinkAdministrator";
            var apiEndpoint = ($"api/account/role/name/{testRole}");
            var url = new RestClientOptions($"{api_Account_MOCKServerURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Users > Commands > POST_CreateUser
        public void Verify_POSTCreateUser()
        {
            var apiEndpoint = "api/account/user";
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Users > Commands > POST_ActivateUser
        public void Verify_POST_ActivateUser()
        {
            var testID = "d990eb97-c9bf-41d3-b58d-11c959784cb3";
            var apiEndpoint = ($"api/account/user/{testID}/activate");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Users > Commands > POST_DeactivateUser
        public void Verify_POST_DeactivateUser()
        {
            var testID = "d990eb97-c9bf-41d3-b58d-11c959784cb3";
            var apiEndpoint = ($"api/account/user/{testID}/deactivate");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Users > Commands > PUT_UpdateUser
        public void Verify_PUT_UpdateUser()
        {
            var testID = "CBEFDB41-5C50-4C34-BB81-13E1EC9CD094";
            var apiEndpoint = ($"api/account/user/{testID}");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Users > Commands > DELETE_User
        public void Verify_DELETE_User()
        {
            var testID = "d990eb97-c9bf-41d3-b58d-11c959784cb3";
            var apiEndpoint = ($"api/account/user/{testID}");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();

            try
            {
                var response = client.Delete(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                var responseDesc = ex.Message;
                testRun.Verify(TestRun.ComparisonType.Contains, responseDesc, "Request failed with status code Unauthorized", "Authorization required as expected");
            }
        }
        #endregion
        #region Account > Users > Commands > POST_RecoverUser
        public void Verify_POST_RecoverUser()
        {
            var testID = "d990eb97-c9bf-41d3-b58d-11c959784cb3";
            var apiEndpoint = ($"api/account/user/{testID}/recover");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Users > Commands > PUT_UpdateUserClaims
        public void Verify_PUT_UpdateUserClaims()
        {
            var testID = "CBEFDB41-5C50-4C34-BB81-13E1EC9CD094";
            var apiEndpoint = ($"api/account/user/{testID}/claims");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Users > Queries > GET_UserByID
        public void Verify_GET_UserByID()
        {
            var testID = "d990eb97-c9bf-41d3-b58d-11c959784cb3";
            var apiEndpoint = ($"api/account/user/{testID}");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Users > Queries > GET_UserByEmail
        public void Verify_GET_UserByEmail()
        {
            var emailAddress = "adam.phillips@lantanagroup.com";
            var apiEndpoint = ($"api/account/user/email/{emailAddress}");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Users > Queries > GET_FacilityUsers
        public void Verify_GET_FacilityUsers()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/account/user/facility/{testFacility}");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Users > Queries > GET_UsersByRole
        public void Verify_GET_UsersByRole()
        {
            var testUser = "LinkUser";
            var apiEndpoint = ($"api/account/user/role/{testUser}");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Users > Queries > GET_SearchUsers
        public void Verify_GET_SearchUsers()
        {
            var apiEndpoint = "api/account/users";
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Users > Queries > GET_SearchFacilityUsers
        public void Verify_GET_SearchFacilityUsers()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/account/user/facility/{testFacility}");
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account > Claims > GET_Claims
        public void Verify_GET_Claims()
        {
            var apiEndpoint = "api/account/claims";
            var url = new RestClientOptions($"{api_AccountURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
    }
}
