using System;
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

namespace API_Integration.Pages.MVP
{
    public class MVP_API_RequestsPage : BasePage
    {
        public MVP_API_RequestsPage(TestRun testRun) : base(testRun)
        {
            this.testRun = testRun;
        }
        #region Page Objects

        #endregion


        #region Patient List

        public void GET_STU3_Patient_List()
        {
            var apiEndpoint = "fhir/List/Stu3-MayPatients";   //MUST UPDATE THIS FOR SPECIFIC ENDPOINT/FILE NAME
            var url = new RestClientOptions($"{api_TenantRequestURL}/{apiEndpoint}")
            {
                Authenticator = new HttpBasicAuthenticator(apiconfig["apiUserName"], apiconfig["apiPassword"])
            };
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);
            var responseCode = response.StatusCode;

            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "OK", "Successful response code received.");

            var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            Console.WriteLine(data);
        }

        #endregion
    }
}
