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
    public class Audit_API_Page : BasePage
    {
        public Audit_API_Page(TestRun testRun) : base(testRun)
        {
            this.testRun = testRun;
        }

        #region Audit_GetAudits
        public void Verify_GETAudits()
        {
            var apiEndpoint = "api/audit";
            var url = new RestClientOptions($"{api_AuditRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion

        #region Audit_GetAudit
        public void Verify_GETAuditByID()
        {
            var auditID = "ae3df49-a198-40fd-b445-34fb2ca02809";
            var apiEndpoint = $"api/audit/{auditID}";
            var url = new RestClientOptions($"{api_AuditRequestURL}/{apiEndpoint}");
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.ExecuteGet(request);

            var responseCode = response.StatusCode;
            var responseDesc = response.StatusDescription;
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseCode, "Unauthorized", "Authorization required as expected");
            testRun.Verify(TestRun.ComparisonType.StringCompareCaseInsensitive, responseDesc, "Unauthorized", "Authorization required as expected");
        }
        #endregion

        #region Audit_GetAuditsByFacility
        public void Verify_GETAuditsByFacility()
        {
            var facilityID = "Hospital1_Static";
            var apiEndpoint = $"api/audit/facility/{facilityID}";
            var url = new RestClientOptions($"{api_AuditRequestURL}/{apiEndpoint}");
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
