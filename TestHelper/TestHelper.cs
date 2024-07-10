using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Net.Http;



namespace TestHelper
{
    public class TestRun
    {
        /// <summary>
        /// The test context for this run
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// An instance of the browser
        /// </summary>
        public Browser Browser { get; set; }

        /// <summary>
        /// How long before the test should time out looking for an object
        /// </summary>
        public TimeSpan Timeout;

        private RunStatusCode runStatus;

        public enum RunStatusCode
        {
            Pass, // test passes
            Fail, // test fails
            Error, // unexpected error in test
            Warning // unable to determine if the test passed or failed
        }

        public enum ComparisonType
        {
            Equals,                 // expected and actual are euqal
            StringCompareCaseInsensitive,  // expected and actual are equal case insensitively
            NotEqual,               // expected and actual are not equal
            GreaterThan,            // expected is greater than actual
            GreaterThanOrEqualTo,   // expected is greater than or equal to actual
            LessThan,               // expected is less than actual
            LessThanOrEqualTo,      // expected is less than or equal to actual
            Contains,               // expected contains actual 
            NotContain,             // expected does not contain actual
            ListContains,           // expected list contains actual
            ListNotContain,         // exptected list does not contain actual
            Url                     // expected url and actual URLare equal, ignore trailing '/' and case insensitive
        }

        /// <summary>
        /// Do any remaining tasks to clean up test run.
        /// Things it currently does:
        /// - Logs any failures
        /// - Kills current webdriver instance
        /// </summary>
        public void CleanUp()
        {
            if (Browser != null)
            {
                LogComment("Close Browser");
                Browser.TearDown();
            }

            //If the test failed during any verification step, then we do an assert so that the logging shows up as failure.
            //This has to be the last step because it'll throw an exception to be caught by the unit test framework
            if (TestRunStatus == RunStatusCode.Fail || TestRunStatus == RunStatusCode.Warning || TestRunStatus == RunStatusCode.Error)
            {
                Assert.Fail("At least 1 verification step failed.  See detailed log results.");
            }
        }

        public void CleanUpChromeDrivers()
        {
            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }
        }

        /// <summary>
        /// Launch an instance of the browser
        /// </summary>
        public void LaunchBrowser()
        {
            Browser = new Browser(TestContext);
            Browser.Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Logs a comment to the console
        /// </summary>
        /// <param name="comment">Comment to log</param>
        public static void LogComment(string comment)
        {
            var currentTime = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine($"{currentTime} - {comment}");
        }

        /// <summary>
        /// Logs results of the run and takes a screenshot if the results is a failure
        /// </summary>
        /// <param name="status">The results of the run</param>
        /// <param name="comments">Comments to attach to the results</param>
        public void LogVerificationResults(RunStatusCode status, string comments)
        {
            TestRunStatus = status;

            LogComment(status.ToString() + " - " + comments);

            //if failure and browser not null, then take a screenshot
            if ((status == RunStatusCode.Fail || status == RunStatusCode.Warning || status == RunStatusCode.Error) && Browser != null)
            {
                DateTime currentTime = DateTime.Now;
                //TakeScreenShot($"{TestContext.TestName}_{DateTime.Now.Ticks}");
            }
        }

        /// <summary>
        /// Constructor that starts the test run
        /// </summary>
        /// <param name="testContext"></param>
        public TestRun(TestContext testContext)
        {
            TestContext = testContext;

            TestRunStatus = RunStatusCode.Pass;
        }

        /// <summary>
        /// The current results of the run. There are constraints on what you can set the results code to base on what the current status is.
        /// For example, if the current status is "Fail", it'll the status will still return a "Fail" if you enter "Pass".  The order of precedence
        /// for the status code is "Error", "Failed", "Warning", "Pass"
        /// </summary>
        public RunStatusCode TestRunStatus
        {
            get
            {
                return runStatus;
            }
            set
            {
                switch (value)
                {
                    case RunStatusCode.Error:
                        runStatus = RunStatusCode.Error;
                        break;
                    case RunStatusCode.Fail:
                        if (runStatus == RunStatusCode.Pass || runStatus == RunStatusCode.Warning)
                        {
                            runStatus = RunStatusCode.Fail;
                        }
                        break;
                    case RunStatusCode.Warning:
                        if (runStatus == RunStatusCode.Pass)
                        {
                            runStatus = RunStatusCode.Warning;
                        }
                        break;
                }
            }
        }

        public void Verify(ComparisonType compareType, object expectedValue, object actualValue, string actualValueDescription) //, string passingComments = "", string failingComments = "")
        {
            //If at least one of the 2 values are null, then we have to handle the comparisons differently
            if (actualValue == null || expectedValue == null)
            {
                switch (compareType)
                {
                    case ComparisonType.Equals:
                        if (actualValue == null && expectedValue == null)
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription} equals null as expected");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValue ?? "null"}' does not equal the expected value '{expectedValue ?? "null"}'");
                        }

                        break;

                    case ComparisonType.StringCompareCaseInsensitive:
                        if (actualValue == null && expectedValue == null)
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription} unexpectly equals null");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValue ?? "null"}' does not equal '{expectedValue ?? "null"}' as expected");
                        }

                        break;

                    case ComparisonType.NotEqual:
                        if (actualValue == null && expectedValue == null)
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription} unexpectly equals null");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValue ?? "null"}' does not equal '{expectedValue ?? "null"}' as expected");
                        }

                        break;

                    case ComparisonType.Url:
                        if (actualValue == null && expectedValue == null)
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription} unexpectly equals null");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValue ?? "null"}' does not equal '{expectedValue ?? "null"}' as expected");
                        }

                        break;

                    default:
                        LogVerificationResults(RunStatusCode.Fail,
                            $"Cannot compare {actualValueDescription} due to a null value");
                        break;
                }
            }
            else
            {
                IComparable actualValueComparableVersion;
                IComparable expectedValueComparableVersion;

                //If actualValue and expectedValue both implements Icomparable, then we convert it to an Icomparable type.
                //If they don't, then we serialize the object first
                if (actualValue is IComparable && expectedValue is IComparable)
                {
                    //Convert the objects to Icomparable type to do comparison
                    actualValueComparableVersion = (IComparable)actualValue;
                    expectedValueComparableVersion = (IComparable)expectedValue;
                }
                else
                {
                    var xmlSerializer1 = new XmlSerializer(actualValue.GetType());
                    using (var textWriter = new StringWriter())
                    {
                        xmlSerializer1.Serialize(textWriter, actualValue);
                        actualValueComparableVersion = textWriter.ToString();
                    }

                    var xmlSerializer2 = new XmlSerializer(expectedValue.GetType());
                    using (var textWriter = new StringWriter())
                    {
                        xmlSerializer2.Serialize(textWriter, expectedValue);
                        expectedValueComparableVersion = textWriter.ToString();
                    }
                }

                //Convert objects to string type to do string comparison
                var actualValueStringVersion = actualValue.ToString();
                var expectedValueStringVersion = expectedValue.ToString();

                switch (compareType)
                {
                    case ComparisonType.Equals:
                        if (actualValueComparableVersion.Equals(expectedValueComparableVersion))
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription} equals '{expectedValueStringVersion}'");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValueComparableVersion}' unexpectedly does not equal '{expectedValueComparableVersion}'");
                        }

                        break;

                    case ComparisonType.StringCompareCaseInsensitive:
                        if (String.Compare(actualValueStringVersion, expectedValueStringVersion, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription} equals '{expectedValueStringVersion}'");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValueComparableVersion}' unexpectedly does not equal '{expectedValueComparableVersion}'");
                        }

                        break;

                    case ComparisonType.NotEqual:

                        if (!actualValueComparableVersion.Equals(expectedValueComparableVersion))
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValueStringVersion}' does not equal '{expectedValueStringVersion}' as expected");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription} unexpectedly equaled '{expectedValueComparableVersion}'");
                        }

                        break;

                    case ComparisonType.LessThan:
                        if (actualValueComparableVersion.CompareTo(expectedValueComparableVersion) < 0)
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValue}' is less than '{expectedValue}' as expected");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValue}' is unexpectedly not less than '{expectedValue}'");
                        }

                        break;

                    case ComparisonType.LessThanOrEqualTo:
                        if (actualValueComparableVersion.CompareTo(expectedValueComparableVersion) <= 0)
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValue}' is less than or equal to '{expectedValue}' as expected");

                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValue}' is unexpectedly not less than or equal to '{expectedValue}'");
                        }

                        break;

                    case ComparisonType.GreaterThan:
                        if (actualValueComparableVersion.CompareTo(expectedValueComparableVersion) > 0)
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValue}' is greater than '{expectedValue}' as expected");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValue}' is unexpectedly not greater than '{expectedValue}'");
                        }

                        break;

                    case ComparisonType.GreaterThanOrEqualTo:
                        if (actualValueComparableVersion.CompareTo(expectedValueComparableVersion) >= 0)
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValue}' is greater than or equal to '{expectedValue}' as expected");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValue}' is unexpectedly not greater than or equal to '{expectedValue}'");
                        }

                        break;

                    case ComparisonType.Contains:
                        if (actualValueStringVersion.Contains(expectedValueStringVersion))
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValueStringVersion}' contains '{expectedValueStringVersion}', as expected");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValueStringVersion}' unexpectedly does not contain '{expectedValueStringVersion}'");
                        }

                        break;

                    case ComparisonType.NotContain:
                        if (!actualValueStringVersion.Contains(expectedValueStringVersion))
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValueStringVersion}' does not contain '{expectedValueStringVersion}' as expected");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualValueStringVersion}' unexpectedly contains '{expectedValueStringVersion}'");
                        }

                        break;
                    case ComparisonType.Url:
                        string expectedUrl = expectedValueStringVersion.EndsWith("/") ? expectedValueStringVersion.Substring(0, expectedValueStringVersion.Length - 1) : expectedValueStringVersion;
                        string actualUrl = actualValueStringVersion.EndsWith("/") ? actualValueStringVersion.Substring(0, actualValueStringVersion.Length - 1) : actualValueStringVersion;

                        if (string.Equals(expectedUrl, actualUrl, StringComparison.OrdinalIgnoreCase))
                        {
                            LogVerificationResults(RunStatusCode.Pass,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualUrl}' equals to to '{expectedUrl}'");
                        }
                        else
                        {
                            LogVerificationResults(RunStatusCode.Fail,
                                $"VERIFY::: {actualValueDescription}'s value of '{actualUrl}' unexpectedly does not equal to '{expectedUrl}'");
                        }

                        break;

                    default:
                        throw new Exception("Invalid comparison type in assert method");
                }
            }
        }

        /// <summary>
        /// Use this function to verify that runsettings is not pointing to Production and prevent tests 
        /// from running in Production
        /// </summary>
        /// <param name="envName">Envvironment name defined in runsettings</param>
        public void VerifyProd(string envName)
        {
            if (envName == "Prod")
            {
                Assert.Inconclusive("This test should not be run in Prod");
            }
        }
    }
    public class UserRole
    {
        public readonly string CancellationApprover = "Cancellation Approver (CRD or Standard)";
        public readonly string CancellationSubmitter = "Cancellation Submitter";
        public readonly string Administrator = "Administrator";
        public readonly string ClaimsApprover = "Claims Approver";
        public readonly string ClaimsAdministrator = "Claims Administrator";
        public readonly string ClaimsAdministratorCanada = "Claims Administrator Canada";
        public readonly string ClaimsApproverCanada = "Claims Approver Canada";
        public readonly string ClaimsManager = "Claims Manager";
        public readonly string ClaimsManagerCanada = "Claims Manager Canada";
        public readonly string Director = "Director";
        public readonly string DirectorCanada = "Director Canada";
        public readonly string PricingManager = "Pricing Manager";
        public readonly string PricingManagerCanada = "Pricing Manager Canada";
        public readonly string ProgramAdminCancellations = "Program Admin - CXL";
        public readonly string ProgramAdminSalesPrograms = "Program Admin - SP";
        public readonly string ReadOnly = "Read Only";
        public readonly string ReadOnlyBudgets = "Read Only Budgets";
        public readonly string ReadOnlyBudgetsCanada = "Read Only Budgets Canada";
        public readonly string SalesManager = "Sales Manager";
        public readonly string SalesManagerCanada = "Sales Manager Canada";
        public readonly string SalesRep = "Sales Rep";
        public readonly string SalesRepCanada = "Sales Rep Canada";
        public readonly string SalesProgramsCreateProgram = "SP Create Program";
        public readonly string SalesProgramsCreateProgramCanada = "SP Create Program - Canada";
        public readonly string SalesProgramsManageDiscounts = "SP Manage Discounts";
        public readonly string SalesProgramsViewProgram = "SP View Program";
        public readonly string SalesProgramsViewProgramCanada = "SP View Program - Canada";
    }
    public class UserUpdateObject
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public List<string> Roles { get; set; }
        public string Aliases { get; set; }
        public DateTime LastActivity { get; set; }
        public string ApplicationName { get; set; }
        public Nullable<int> RepNumber { get; set; }
        public string DisplayName { get; set; }
        public bool HasProfile { get; set; }
        public bool ProfileUpdated { get; set; }
        public bool IsActive { get; set; }
        public bool IsActiveDirectoryUser { get; set; }
        public bool IsDirty { get; set; }
    }
}
