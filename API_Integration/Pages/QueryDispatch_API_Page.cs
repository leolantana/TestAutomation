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
    public class QueryDispatch_API_Page : BasePage
    {
        public QueryDispatch_API_Page(TestRun testRun) : base(testRun)
        {
            this.testRun = testRun;
        }
        #region Query Dispatch
        public void Verify_GET_QueryDispatchByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/querydispatch/configuration/facility/{testFacility}");
            var url = new RestClientOptions($"{api_QueryDispatchURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }

        public void Verify_PUT_QueryDispatchByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/querydispatch/configuration/facility/{testFacility}");
            var url = new RestClientOptions($"{api_QueryDispatchURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePut(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }

        public void Verify_POST_QueryDispatchByFacility()
        {
            var apiEndpoint = "api/querydispatch/configuration";
            var url = new RestClientOptions($"{api_QueryDispatchURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecutePost(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        public void Verify_DELETE_QueryDispatchByFacility()
        {
            var testFacility = "Hospital1";
            var apiEndpoint = ($"api/querydispatch/configuration/facility/{testFacility}");
            var url = new RestClientOptions($"{api_QueryDispatchURL}/{apiEndpoint}");
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
