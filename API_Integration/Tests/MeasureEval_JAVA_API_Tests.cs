using API_Integration.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHelper;

namespace API_Integration.Tests
{
    [TestClass]
    public class MeasureEval_JAVA_API_Tests
    {
        private TestContext testContextInstance;
        private TestRun testRun;
        private Browser browser;

        // variables defined in .runsettings       
        private string envName;
        private string requestURL;

        /// <summary>
        /// Creates an instance of the TestContext
        /// </summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            envName = (string)testContextInstance.Properties["environmentName"];
            requestURL = (string)testContextInstance.Properties["requestURL"];
            testRun = new TestRun(TestContext);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            testRun.CleanUp();
        }
        #region Measure Eval JAVA
        [TestMethod]
        [TestCategory("API_VerifyAuthenticationRequired")]
        public void Verify_GET_AllMeasureDefs()
        {
            MeasureEval_JAVA_API_Page api = new MeasureEval_JAVA_API_Page(testRun);
            api.Verify_GET_AllMeasureDefs();
        }
        public void Verify_GET_SingleMeasureDef()
        {
            MeasureEval_JAVA_API_Page api = new MeasureEval_JAVA_API_Page(testRun);
            api.Verify_GET_SingleMeasureDef();
        }
        public void Verify_PUT_SingleMeasureDef()
        {
            MeasureEval_JAVA_API_Page api = new MeasureEval_JAVA_API_Page(testRun);
            api.Verify_PUT_SingleMeasureDef();
        }
        #endregion
    }
}
