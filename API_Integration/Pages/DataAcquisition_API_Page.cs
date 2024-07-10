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
    public class DataAcquisition_API_Page : BasePage
    {
        public DataAcquisition_API_Page(TestRun testRun) : base(testRun)
        {
            this.testRun = testRun;
        }

        #region Authentication Config
        public void Verify_GET_AuthSettingsByFacility_ConfigType()
        {
            var testFacility = "Hospital1";
            var queryConfigTypePathParameter = "fhirQueryConfiguration";
            var apiEndpoint = ($"api/data/{testFacility}/{queryConfigTypePathParameter}/authentication");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_POST_CreateAuthSettingsForFacility()
        {
            var testFacility = "Hospital1";
            var queryConfigTypePathParameter = "fhirQueryConfiguration";
            var apiEndpoint = ($"api/data/{testFacility}/{queryConfigTypePathParameter}/authentication");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_PUT_UpdateAuthSettingsForFacility()
        {
            var testFacility = "Hospital1";
            var queryConfigTypePathParameter = "fhirQueryConfiguration";
            var apiEndpoint = ($"api/data/{testFacility}/{queryConfigTypePathParameter}/authentication");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_Delete_AuthSettingsForFacility()
        {
            var testFacility = "Hospital1";
            var queryConfigTypePathParameter = "fhirQueryConfiguration";
            var apiEndpoint = ($"api/data/{testFacility}/{queryConfigTypePathParameter}/authentication");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
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
        #region Connection Validation
        public void Verify_GET_ConnectionValidation()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/connectionValidation/{testFacility}/$validate");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Query Config
        public void Verify_GET_FHIRQueryConfigByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/fhirQueryConfiguration");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_DELETE_FHIRQueryConfigByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/fhirQueryConfiguration");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
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
        public void Verify_POST_FHIRQueryConfigByFacility()
        {
            var apiEndpoint = "api/data/fhirQueryConfiguration";
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_PUT_FHIRQueryConfigByFacility()
        {
            var apiEndpoint = "api/data/fhirQueryConfiguration";
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Query List
        public void Verify_GET_FHIRQueryListByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/fhirQueryList");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_POST_FHIRQueryListByFacility()
        {
            var testFacility = "Hospital1_static";
            var apiEndpoint = ($"api/data/{testFacility}/fhirQueryList");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Query Plan Config
        public void Verify_GET_QueryPlanByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/QueryPlan");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_POST_QueryPlanByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/QueryPlan");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_PUT_QueryPlanByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/data/{testFacility}/QueryPlan");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
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
            var apiEndpoint = ($"api/data/{testFacility}/QueryPlan");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
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
        #region Query Result
        public void Verify_GET_QueryResultsByCorrelationID()
        {
            var testFacility = "Hospital1";
            var correlationID = "23eae6b9-804a-420a-9bf0-6a2e2f7a8e49";
            var apiEndpoint = ($"api/data/{testFacility}/QueryResult/{correlationID}");
            var url = new RestClientOptions($"{api_DataAcquisitionRequestURL}/{apiEndpoint}");
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
