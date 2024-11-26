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
using System.Diagnostics;

namespace API_Integration.Pages
{
    public class LinkAdminBFF_Page : BasePage
    {

        public LinkAdminBFF_Page(TestRun testRun) : base(testRun)
        {
            this.testRun = testRun;
        }

        #region Event Generation
        public void Verify_POSTGeneratePatientEvent()
        {
            var apiEndpoint = "api/integration/patient-event";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_POSTGenerateReportScheduledEvent()
        {
            var apiEndpoint = "api/integration/report-scheduled";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_POSTGenerateDataAcquisitionRequestedEvent()
        {
            var apiEndpoint = "api/integration/data-acquisition-requested";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Link Bearer Service
        public void Verify_GETGetLinkToken()
        {
            var apiEndpoint = "api/auth/token";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_GETRefreshSigningKey()
        {
            var apiEndpoint = "api/auth/refresh-key";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Account Service
        #region Account > Roles > Commands > POST_CreateRole
        public void Verify_POSTCreateRole()
        {
            var apiEndpoint = "api/account/role";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #endregion
        #region Audit Service
        #region Audit > Queries > GetAudits
        public void Verify_GETAudits()
        {
            var apiEndpoint = "api/audit";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Audit > Queries > GetAudit
        public void Verify_GETAuditByID()
        {
            var auditID = "ae3df49-a198-40fd-b445-34fb2ca02809";
            var apiEndpoint = $"api/audit/{auditID}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Audit > Queries > GetAuditsByFacility
        public void Verify_GETAuditsByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/audit/facility/{facilityID}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }







        #endregion
        #endregion
        #region Census Service
        #region Census > Configuration > Queries
        public void Verify_GETConfigurationByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/census/config/{facilityID}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Census > Configuration > Commands
        public void Verify_POSTCensusConfiguration()
        {
            var apiEndpoint = "api/census/config";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_PUTConfigurationByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/census/config/{facilityID}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_DELETEConfigurationByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/census/config/{facilityID}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
        #region Census
        public void Verify_GETCurrentCensusByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/census/{facilityID}/current";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #endregion 
        #region Data Acquisition Service
        #region Data Acquisition Service > Query Plan > Commands
        public void Verify_POST_QueryPlanByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/QueryPlans");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_PUT_UpdateQueryPlanByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/query-plan-type");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_DELETE_QueryPlanByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/query-plan-type");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
        #region Data Acquisition Service > Query Plan > Queries
        public void Verify_GET_QueryPlanByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/QueryPlans");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Data Acquisition Service > Query Configuration > Commands
        public void Verify_POST_FHIRQueryConfigByFacility()
        {
            var apiEndpoint = "api/data/fhirQueryConfiguration";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_DELETE_FHIRQueryConfigByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/fhirQueryConfiguration");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
        public void Verify_PUT_FHIRQueryConfigByFacility()
        {
            var apiEndpoint = "api/data/fhirQueryConfiguration";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Data Acquisition Service > Query Configuration > Queries
        public void Verify_GET_FHIRQueryConfigByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/fhirQueryConfiguration");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Data Acquisition Service > Query List > Commands
        public void Verify_POST_FHIRQueryListByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/fhirQueryList");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Data Acquisition Service > Query List > Queries
        public void Verify_GET_FHIRQueryListByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/fhirQueryList");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        //I see a GET Create Query List Config request that appears to be a dupe here? 
        public void Verify_GET_ConnectionValidation()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/connectionValidation/{testFacility}/$validate");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_GET_QueryResultsByCorrelationID()
        {
            var testFacility = "Hospital1";
            var correlationID = "23eae6b9-804a-420a-9bf0-6a2e2f7a8e49";
            var apiEndpoint = ($"api/data/{testFacility}/QueryResult/{correlationID}");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Measure Evaluation Service
        #region Measure Definition > Commands
        public void Verify_PUT_SingleMeasureDef()
        {
            var testMeasureID = "NHSNdQMAcuteCareHospitalInitialPopulation";
            var apiEndpoint = ($"api/measure-definition/{testMeasureID}");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Measure Definition > Queries

        public void Verify_GET_AllMeasureDefs()
        {
            var apiEndpoint = "api/measure-definition";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_GET_SingleMeasureDef()
        {
            var testMeasureID = "NHSNdQMAcuteCareHospitalInitialPopulation";
            var apiEndpoint = ($"api/measure-definition/{testMeasureID}");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #endregion
        #region Normalization Service
        #region Normalization Service > Configuration > Commands
        public void Verify_POST_NormalizationConfigByFacility()
        {
            var apiEndpoint = "api/Normalization";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_PUT_NormalizationConfigByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/Normalization/{testFacility}");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_DELETE_NormalizationConfigByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/Normalization/{testFacility}");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
        #region Normalization Service > Configuration > Queries
        public void Verify_GET_NormalizationConfigByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/Normalization/{testFacility}");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #endregion
        #region Notification Service
        #region Notification Service > Configuration > Commands
        public void Verify_POSTNotificationConfiguration()
        {
            var apiEndpoint = "api/notification/configuration";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_PUTNotificationConfiguration()
        {
            var apiEndpoint = "api/notification/configuration";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_DELETEConfigurationByID()
        {
            var testConfigID = "3d940fdb-cdb3-4b96-9bfc-8b03430b3fba";
            var apiEndpoint = $"api/notification/configuration/{testConfigID}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
        #region Notification Service > Configuration > Queries
        public void Verify_GETNotificationConfiguration()
        {
            var apiEndpoint = "api/notification/configuration";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_GETNotificationConfigurationByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = $"api/notification/configuration/facility/{testFacility}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_GETNotificationConfigurationByID()
        {
            var testNotificationConfigID = "fdeff6e1-e15f-41df-8c4e-49d05b49c3a9";
            var apiEndpoint = $"api/notification/configuration/{testNotificationConfigID}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Notifications > Queries
       public void Verify_GETNotificationByID()
        {
            var testNotificationID = "346b59b0-08a1-4ce9-90d7-6c6ed07d6509";
            var apiEndpoint = $"api/notification/{testNotificationID}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_GETNotificationsByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = $"api/notification/facility/{testFacility}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_GETNotifications()
        {
            var apiEndpoint = "api/notification";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #endregion
        #region Report Service
        #region Report Service > Configuration > Commands
        public void Verify_POST_ReportConfig()
        {
            var apiEndpoint = "api/ReportConfig/Create";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_PUT_ReportConfig()
        {
            var apiEndpoint = "api/ReportConfig/Update";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_DELETE_ReportConfig()
        {
            var apiEndpoint = "api/ReportConfig/Delete";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
        #region Report Service > Configuration > Queries
        public void Verify_GET_ReportConfig()
        {
            var apiEndpoint = "api/ReportConfig/Get";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_GET_ReportConfigByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/ReportConfig/facility/{testFacility}");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Report > Queries
        public void Verify_GET_Bundle_Patient()
        {
            var apiEndpoint = "api/Report/Bundle/Patient";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #endregion
        #region Tenant Service
        #region Tenant Service > Commands
        public void Verify_POSTFacilities()
        {
            var apiEndpoint = "api/Facility";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_PUTFacility()
        {
            var testFacility = "Hospital1_Static";
            var apiEndpoint = $"api/Facility/{testFacility}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_DELETEFacility()
        {
            var testFacility = "Hospital1_Static";
            var apiEndpoint = $"api/Facility/{testFacility}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
        #region Tenant Service > Queries
        public void Verify_GETFacilities()
        {
            var apiEndpoint = "api/Facility";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_GETFacility()
        {
            var testFacility = "Hospital1_Static";
            var apiEndpoint = $"api/Facility/{testFacility}";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #endregion
        #region Query Dispatch Service
        #region Query Dispatch Service > Configuration > Commands
        public void Verify_POST_QueryDispatchByFacility()
        {
            var apiEndpoint = "api/querydispatch/configuration";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_PUT_QueryDispatchByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/querydispatch/configuration/facility/{testFacility}");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_DELETE_QueryDispatchConfigByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/querydispatch/configuration/facility/{testFacility}");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
        #region Query Dispatch Service > Configuration > Queries
        public void Verify_GET_QueryDispatchByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/querydispatch/configuration/facility/{testFacility}");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #endregion
        #region Submission Service
        #region Submission Service > Configuration > Commands
        public void Verify_POST_CreateSubmissionConfiguration()
        {
            var apiEndpoint = ("api/TenantSubmission/Create");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_PUT_UpdateSubmissionConfiguration()
        {
            var apiEndpoint = ("api/TenantSubmission/Update");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_DELETE_SubmissionConfiguration()
        {
            var apiEndpoint = ("api/TenantSubmission/Delete");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
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
        #region Submission Service > Configuration > Queries
        public void Verify_GET_SubmissionConfiguration()
        {
            var apiEndpoint = ("api/TenantSubmission/Get");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_GET_FacilitySubmissionConfiguration()
        {
            var apiEndpoint = ("api/TenantSubmission/Find");
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #endregion
        #region Link Admin BFF General
        public void Verify_GET_User()
        {
            var apiEndpoint = "api/user";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_GET_APIInfo()
        {
            var apiEndpoint = "api/info";
            var url = new RestClientOptions($"{api_LinkAdminBffURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion

        #region End to End Requests
        public async Task ValidateStaticFacilityExists()
        {
            var options = new RestClientOptions("https://dev-demo.nhsnlink.org")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/Facility", Method.Get);
            request.AddHeader("Authorization", "Bearer "+bearerToken);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);

            JObject jsonResponse = JObject.Parse(response.Content);

            // Extract the "records" array from the JSON response
            JArray records = (JArray)jsonResponse["records"];

            // Check if any facilityName is "Hospital1_static"
            bool facilityExists = false;

            foreach (var record in records)
            {
                if (record["facilityName"].ToString() == "Hospital1_static")
                {
                    facilityExists = true;
                    break;
                }
            }

            // Output the result
            if (facilityExists)
            {
                Console.WriteLine("\"Hospital1_static\" exists in the response.");
            }
            else
            {
                Console.WriteLine("\"Hospital1_static\" does not exist in the response.");
            }
        }
        #endregion
    }
}
