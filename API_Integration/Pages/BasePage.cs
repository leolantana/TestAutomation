using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Diagnostics;

namespace API_Integration.Pages
{
    public class BasePage
    {
        public Browser browser;
        public WebDriverWait driverWait;
        public TestContext testContext;
        public TestRun testRun;
        public string apiEnvName;
        public string api_TenantRequestURL;
        public string api_AuditRequestURL;
        public string localhost_Tenant_api_Base;
        public string api_NotificationRequestURL;
        public string api_CensusRequestURL;
        public string api_AccountURL;
        public string api_Account_MOCKServerURL;
        public string api_DataAcquisitionRequestURL;
        public string api_NormalizationRequestURL;
        public string api_QueryDispatchURL;
        public string api_ReportURL;
        public string api_MeasureURL;
        public string api_LinkAdminBffURL;
        public IConfigurationRoot apiconfig;
        public string bearerToken = "eyJhbGciOiJSUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICJoN19Yamd3OGlCZFFNbVl1M3gyQk56dXcwcnFFeVFRbVFyLTdnTWNuVXBrIn0.eyJleHAiOjE3MjU5ODc3MjAsImlhdCI6MTcyNTk4NTkyMCwiYXV0aF90aW1lIjoxNzI1OTg1OTE5LCJqdGkiOiI2MDhhN2RlZS00MmU4LTQ4YmUtYjk2NS0wNjIxMWEwNTFlM2MiLCJpc3MiOiJodHRwczovL29hdXRoLm5oc25saW5rLm9yZy9yZWFsbXMvTkhTTkxpbmsiLCJhdWQiOlsibGluay1ib3R3IiwiYWNjb3VudCJdLCJzdWIiOiJhN2UxZGNmZS1hMWVlLTQxNDAtOTM5Ni1lNzhlZGNjYTE4MjMiLCJ0eXAiOiJCZWFyZXIiLCJhenAiOiJsaW5rLWJvdHciLCJzZXNzaW9uX3N0YXRlIjoiZjk1OTZkYjctODc4ZC00MzlkLTkxZWUtN2NiM2Q5YzRmNDYwIiwiYWxsb3dlZC1vcmlnaW5zIjpbImh0dHBzOi8vZGV2LWRlbW8tYXBwLmFjYS1kZXYubmhzbmxpbmsub3JnIiwiaHR0cHM6Ly9kZXYtZGVtby5uaHNubGluay5vcmciLCJodHRwczovL2Rldi1kZW1vLWFwcC5kZWxpZ2h0ZnVsZmllbGQtMWYxNDljN2Euc291dGhjZW50cmFsdXMuYXp1cmVjb250YWluZXJhcHBzLmlvIiwiaHR0cDovL2xvY2FsaG9zdDo0MjAwIl0sInJlYWxtX2FjY2VzcyI6eyJyb2xlcyI6WyJkZWZhdWx0LXJvbGVzLW5oc25saW5rIiwib2ZmbGluZV9hY2Nlc3MiLCJ1bWFfYXV0aG9yaXphdGlvbiJdfSwicmVzb3VyY2VfYWNjZXNzIjp7ImFjY291bnQiOnsicm9sZXMiOlsibWFuYWdlLWFjY291bnQiLCJtYW5hZ2UtYWNjb3VudC1saW5rcyIsInZpZXctcHJvZmlsZSJdfX0sInNjb3BlIjoib3BlbmlkIHByb2ZpbGUgZW1haWwgYm90d2RlbW9nYXRld2F5YXBpLnJlYWQiLCJzaWQiOiJmOTU5NmRiNy04NzhkLTQzOWQtOTFlZS03Y2IzZDljNGY0NjAiLCJlbWFpbF92ZXJpZmllZCI6dHJ1ZSwiaXAiOiIxNzMuMTguNzIuMTA2Iiwicm9sZXMiOlsiZGVmYXVsdC1yb2xlcy1uaHNubGluayIsIm9mZmxpbmVfYWNjZXNzIiwidW1hX2F1dGhvcml6YXRpb24iXSwibmFtZSI6IkxlbyBIaWdsZXkiLCJwcmVmZXJyZWRfdXNlcm5hbWUiOiJsZW8uaGlnbGV5QGxhbnRhbmFncm91cC5jb20iLCJnaXZlbl9uYW1lIjoiTGVvIiwiZmFtaWx5X25hbWUiOiJIaWdsZXkiLCJlbWFpbCI6Imxlby5oaWdsZXlAbGFudGFuYWdyb3VwLmNvbSJ9.p3R4XkxfjDQ8CGM7EdLkF4bkoCH_zbAgb7dp9GL706UFbkxttzwneZknjXO7KZsF4sMYt_khnUNnXwAVnt4lrUKC1sDoH9XqTKVu7M4BUMMn7gCmDdwRl870fkUqVEP17HD6vI1sHrjQFyxfuJYEcJZzj7sodYHXnCqvEWGPa8x9y2-gBJ9SdJeDEQbMqm_m0orxzosCvPh3TqwCf9r85tCg6Z8nYyiVBIJg3pL3RvXrR99Rj6ZMdXW7Fg32QhiWBbM2xg9pB8QKfmEVwKSjPSW9KCDF76UTVsrh3o7GmWTeUBFm8w3RDBJF92TRtTXygNUO5N338f2neUvwagWlTw";

    
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="testRun">Instance of the test run</param>
        /// 
        public BasePage(TestRun testRun)
        {
            this.testRun = testRun;
            this.browser = testRun.Browser;
            this.testContext = testRun.TestContext;
            apiEnvName = (string)testContext.Properties["apiEnvironmentName"];
            apiconfig = new ConfigurationBuilder().AddJsonFile("apiappsettings.json").Build();
            localhost_Tenant_api_Base = (string)testContext.Properties["localhost_Tenant_api_Base"];
            api_Account_MOCKServerURL = (string)testContext.Properties["api_Account_MOCKServerURL"];
            api_TenantRequestURL = (string)testContext.Properties["api_TenantRequestURL"];
            api_AuditRequestURL = (string)testContext.Properties["api_AuditRequestURL"];
            api_NotificationRequestURL = (string)testContext.Properties["api_NotificationRequestURL"];
            api_CensusRequestURL = (string)testContext.Properties["api_CensusRequestURL"];
            api_AccountURL = (string)testContext.Properties["api_AccountURL"];
            api_DataAcquisitionRequestURL = (string)testContext.Properties["api_DataAcquisitionRequestURL"];
            api_NormalizationRequestURL = (string)testContext.Properties["api_NormalizationRequestURL"];
            api_QueryDispatchURL = (string)testContext.Properties["api_QueryDispatchURL"];
            api_ReportURL = (string)testContext.Properties["api_ReportURL"];
            api_MeasureURL = (string)testContext.Properties["api_MeasureURL"];
            api_LinkAdminBffURL = (string)testContext.Properties["api_LinkAdminBffURL"];
        }
    }
}
