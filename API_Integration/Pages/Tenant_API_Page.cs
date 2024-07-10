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
    public class Record
    {
        public string Id { get; set; }
        public string FacilityId { get; set; }
        public string FacilityName { get; set; }
        public List<object> MonthlyReportingPlans { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }

    public class RootObject
    {
        public List<Record> Records { get; set; }
    }

    public class Tenant_API_Page : BasePage
    {
        public Tenant_API_Page(TestRun testRun) : base(testRun)
    {
        this.testRun = testRun;
    }

        #region StaticTestFacility

        public void Verify_StaticTestFacilityExists()
        {
            var apiEndpoint = "api/Facility";
            var url = new RestClientOptions($"{localhost_Tenant_api_Base}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "OK", "Successful response code received.");

            var rootObject = JsonConvert.DeserializeObject<RootObject>(response.Content);
            string facilityId = rootObject.Records[0].FacilityId;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, facilityId, "Hospital1_static", "Facility exists and is correct.");
        }
        #endregion

        #region Tenant_GetFacilities

        public void Verify_GETFacilities()
        {
            var apiEndpoint = "api/Facility";
            var url = new RestClientOptions($"{api_TenantRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion

        #region Tenant_POSTFacilities

        public void Verify_POSTFacilities()
        {
            var apiEndpoint = "api/Facility";
            var url = new RestClientOptions($"{api_TenantRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion

        #region Tenant_GETFacility
        public void Verify_GETFacility()
        {
            var apiEndpoint = "api/Facility/Hospital1_Static";
            var url = new RestClientOptions($"{api_TenantRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion

        #region Tenant_DELETEFacility
        public void Verify_DELETEFacility()
        {
            var apiEndpoint = "api/Facility/Hospital1_Static";
            var url = new RestClientOptions($"{api_TenantRequestURL}/{apiEndpoint}");
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

        #region Tenant_PUTFacility
        public void Verify_PUTFacility()
        {
            var apiEndpoint = "api/Facility/Hospital1_Static";
            var url = new RestClientOptions($"{api_TenantRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion

    }
}
