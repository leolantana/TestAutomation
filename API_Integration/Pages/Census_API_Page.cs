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
    public class Census_API_Page : BasePage
    {
        public Census_API_Page(TestRun testRun) : base(testRun)
        {
            this.testRun = testRun;
        }

        #region Census_GETPatientHistoryByFacility

        public void Verify_GETPatientHistoryByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/census/{facilityID}/history";
            var url = new RestClientOptions($"{api_CensusRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Census_GETAdmittedPatientHistoryByFacility

        public void Verify_GETAdmittedPatientHistoryByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/census/{facilityID}/history/admitted";
            var url = new RestClientOptions($"{api_CensusRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Census_GETCurrentCensusByFacility

        public void Verify_GETCurrentCensusByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/census/{facilityID}/current";
            var url = new RestClientOptions($"{api_CensusRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region Census_GETAllPatientsByFacility

        public void Verify_GETAllPatientsByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/census/{facilityID}/all";
            var url = new RestClientOptions($"{api_CensusRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region CensusConfiguration_POSTConfiguration
        public void Verify_POSTCensusConfiguration()
        {
            var apiEndpoint = "api/census/config";
            var url = new RestClientOptions($"{api_CensusRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region CensusConfiguration_GETConfigurationByFacility
        public void Verify_GETConfigurationByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/census/config/{facilityID}";
            var url = new RestClientOptions($"{api_CensusRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region CensusConfiguration_PUTConfigurationByFacility
        public void Verify_PUTConfigurationByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/census/config/{facilityID}";
            var url = new RestClientOptions($"{api_CensusRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion
        #region CensusConfiguration_DELETEConfigurationByID
        public void Verify_DELETEConfigurationByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/census/config/{facilityID}";
            var url = new RestClientOptions($"{api_CensusRequestURL}/{apiEndpoint}");
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
    }
}
