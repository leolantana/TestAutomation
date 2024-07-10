using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TestHelper;

//namespace TestHelper.UIHelper
namespace TestHelper
{
    //public class UIHelper
    //{

    //}
    public class Browser
    {
        private TestContext testContext;
        public IWebDriver Driver { get; set; }

        private IList<string> windowHandles = new List<string>(); // list of windows in control of driver

        public Browser(TestContext testContext)
        {
            this.testContext = testContext;
            LaunchBrowser();
        }

        public void LaunchBrowser()
        {
            TimeSpan commandTimeout = TimeSpan.FromSeconds(120); // time allowed for each command to timeout
            string browserType = testContext.Properties["browserType"].ToString();
            string gridServer = testContext.Properties["gridServer"].ToString();

            if (browserType.ToLower() == "chrome") // Chrome
            {
                var options = new ChromeOptions();
                options.AddArgument("start-maximized");
                options.AddArgument("disable-infobars");
                options.AddArgument("incognito");
                options.AddArgument("use-fake-device-for-media-stream"); // added to allow camera to be used in Chrome and disable notification
                options.AddArgument("use-fake-ui-for-media-stream"); // added to allow camera to be used in Chrome and disable notification
                options.AddUserProfilePreference("credentials_enable_service", false);
                options.AddUserProfilePreference("password_manager_enabled", false);

                Driver = new ChromeDriver();
            }
            else if (browserType.ToLower() == "firefox") // Firefox
            {
                var options = new FirefoxOptions();
                Driver = new RemoteWebDriver(new Uri(gridServer), options.ToCapabilities(), commandTimeout);
            }
            else if (browserType.ToLower() == "ie") // Internet Explorer
            {
                var options = new InternetExplorerOptions();
                options.EnableNativeEvents = false;
                options.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
                options.IgnoreZoomLevel = true;
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                options.EnablePersistentHover = true;
                Driver = new RemoteWebDriver(new Uri(gridServer), options.ToCapabilities(), commandTimeout);
            }
            else if (browserType.ToLower() == "edge")
            {
                var options = new EdgeOptions();

                Driver = new RemoteWebDriver(new Uri(gridServer), options.ToCapabilities(), commandTimeout);
            }
            else
            {
                throw new Exception("Browser type specified in the config is not recognized");
            }

            AddWindow();
        }

        /// <summary>
        /// Adds the new window handle to the WindowHandle list.  This function needs to be called anyime there is a popup to keep the window handles in sync.
        /// </summary>
        /// <remarks>Selenium has a function that returns the current window handles, but not in any particular order, so we have to keep our own list sorted in order of appearance.</remarks>
        public void AddWindow()
        {
            SyncWindowsList();  //sync first to make sure that windowhandles doesn't have any orphan handles
            IReadOnlyCollection<string> newListWinHandle = Driver.WindowHandles;

            //wait until new window pops up
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            TimeSpan timeout = TimeSpan.FromSeconds(120);

            do
            {
                if (stopwatch.Elapsed > timeout)
                {
                    throw new Exception("Not able to add new window");
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
                newListWinHandle = Driver.WindowHandles;

            } while (newListWinHandle.Count <= windowHandles.Count);


            //compare the old list of handles to the new list and add any new windows to the old list
            //The reason we want to keep our own list of windowhandles is that we can keep it in order of appearance.
            //the selenium WindowHandles property returns a list of current handles in random order
            foreach (string handle in newListWinHandle)
            {
                //If the handle is not in the list, then add it
                if (!windowHandles.Contains(handle))
                {
                    windowHandles.Add(handle);
                }
            }
        }

        /// <summary>
        /// Cleans up the windowhandle list just in case there are windows that got automatically closed by the web site without calling the CloseWindow function.
        /// If user clicks on the Close button  to close a window, then this function needs to be called.  This does not add new windows.
        /// </summary>
        public void SyncWindowsList()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));// just sleeping for a few seconds to let things settle down 
            IList<string> newListWinHandle = Driver.WindowHandles;
            IList<string> tempList = new List<string>();

            foreach (string handle in windowHandles)
            {
                //if the handle in our list still exist, then keep it.
                if (newListWinHandle.Contains(handle))
                {
                    tempList.Add(handle);
                }
            }

            windowHandles = tempList;  //copy everything back to the list
        }


        /// <summary>
        /// Takes a screenshot and saves it as a jpeg file
        /// </summary>
        /// <param name="fileName">The name of the file to save as.  You do not need to put the file extension</param>
        /// <example>TakeScreenshot("MyScreenshot")</example>
        //public void TakeScreenShot(string fileName)
        //{
        //    TestRun.LogComment("Attempting to take a screenshot");

        //    string directory = $"{testContext.TestResultsDirectory}\\Screenshots"; // AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\Screenshots\";
        //    string filePath = $"{directory}\\{fileName}.jpg";

        //    try
        //    {
        //        //if directory doesn't exist, then create it
        //        if (!Directory.Exists(directory))
        //        {
        //            Directory.CreateDirectory(directory);
        //        }

        //        //take screenshot and save it
        //        ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(filePath, ScreenshotImageFormat.Jpeg);
        //        testContext.AddResultFile(filePath);
        //        TestRun.LogComment($"Successfully created screenshot file '{filePath}'");
        //    }
        //    catch
        //    {
        //        TestRun.LogComment("Unable to take a screenshot");
        //    }
        //}

        /// <summary>
        /// Does the cleanup after a script is run.  Closes browser.
        /// </summary>
        public void TearDown()
        {
            ////If the test failed due to exception or something else, then take a screenshot
            //if (testContext.CurrentTestOutcome == UnitTestOutcome.Failed || testContext.CurrentTestOutcome == UnitTestOutcome.Error)
            //{
            //    var currentTime = DateTime.Now;
            //    TakeScreenShot($"{testContext.TestName}_{currentTime.ToString("yyyyMMddHHmmss")}");
            //}

            //clean up
            if (Driver != null)
            {
                Driver.Manage().Cookies.DeleteAllCookies();
                Driver.Dispose();
                Driver.Quit();
                TestRun.LogComment("Tore down webdriver");
            }
        }

        /// <summary>
        /// This function checks for the ajax loading image and waits until it disappears. 
        /// It uses a known list of ajax objects
        /// </summary>
        public void WaitForAjax(int initalWaitTimeInSeconds = 1)
        {
            var stopwatch = new Stopwatch();

            //sleep for a second, just to let things settle and the ajax spinner to load. May need to increase this if ajax loading takes a long time
            Thread.Sleep(TimeSpan.FromSeconds(initalWaitTimeInSeconds));

            bool ajaxFound = false;  //Using this boolean so that we only detect 1 type of ajax loader so that the code will run faster.  If we need to at a later time, we can remove this check if there are multiple ajax loaders on the same page.

            var timeOutPeriod = TimeSpan.FromSeconds(600);

            stopwatch.Start();


            //Use the below Try/Catch to add condtions for which to wait
            try
            {
                //    //while the "wait" image is displayed, wait until it is done to continue
                //    //Loop and check every 100 millisecond
                while (ExistsAndDisplayed(By.ClassName("x-mask-msg-text")) && stopwatch.Elapsed < timeOutPeriod)
                {
                    ajaxFound = true;
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
            //    while (ExistsAndDisplayed(By.ClassName("admin__data-grid-loading-mask")) && stopwatch.Elapsed < timeOutPeriod)
            //    {
            //        // spinner in magento admin
            //        ajaxFound = true;
            //        Thread.Sleep(TimeSpan.FromMilliseconds(100));
            //    }
            //    while (ExistsAndDisplayed(By.ClassName("src-components-Spinner-_styles-module_skCube2_3nLQC")) && stopwatch.Elapsed < timeOutPeriod)
            //    {
            //        // spinner in SkuNexus - Add Scanned SKU on Receive Inventory
            //        ajaxFound = true;
            //        Thread.Sleep(TimeSpan.FromMilliseconds(100));
            //    }
            //    while (ExistsAndDisplayed(By.ClassName("loading-indicator")) && stopwatch.Elapsed < timeOutPeriod)
            //    {
            //        ajaxFound = true;
            //        Thread.Sleep(TimeSpan.FromMilliseconds(100));
            //    }
            //    while (ExistsAndDisplayed(By.Id("wait")) && stopwatch.Elapsed < timeOutPeriod)
            //    {
            //        ajaxFound = true;
            //        Thread.Sleep(TimeSpan.FromMilliseconds(100));
            //    }
            //    while (ExistsAndDisplayed(By.ClassName("blockUI")) && stopwatch.Elapsed < timeOutPeriod)
            //    {
            //        ajaxFound = true;
            //        Thread.Sleep(TimeSpan.FromMilliseconds(100));
            //    }
            //    while (ExistsAndDisplayed(By.ClassName("blockUI.blockOverlay")) && stopwatch.Elapsed < timeOutPeriod)
            //    {
            //        ajaxFound = true;
            //        Thread.Sleep(TimeSpan.FromMilliseconds(100));
            //    }
            //    while (ExistsAndDisplayed(By.ClassName("blockUI.blockMsg.blockPage")) && stopwatch.Elapsed < timeOutPeriod)
            //    {
            //        ajaxFound = true;
            //        Thread.Sleep(TimeSpan.FromMilliseconds(100));
            //    }
            //    while (ExistsAndDisplayed(By.ClassName("WaitInfoCell")) && stopwatch.Elapsed < timeOutPeriod)
            //    {
            //        ajaxFound = true;
            //        Thread.Sleep(TimeSpan.FromMilliseconds(100));
            //    }
            //    while (ExistsAndDisplayed(By.XPath("//div[@style!='display:none;']/img[@id='PageBody_Image1']")) && stopwatch.Elapsed < timeOutPeriod)
            //    {
            //        ajaxFound = true;
            //        Thread.Sleep(TimeSpan.FromMilliseconds(100));
            //    }
            //    while (!ExistsAndDisplayed(By.XPath("//div[@data-role='spinner'][@style='display: none;']")) && stopwatch.Elapsed < timeOutPeriod)
            //    {
            //        ajaxFound = true;
            //        Thread.Sleep(TimeSpan.FromMilliseconds(100));
            //    }

                //    //wait for another quarter second for everything to load and then continue
                //    if (ajaxFound)
                //    {
                //        Thread.Sleep(TimeSpan.FromSeconds(.25));
                //        return;
                //    }
                }
            catch (StaleElementReferenceException)
            {
                //    //Do nothing if there is a stale element exception.  We don't care what happens to the ajax loader icon when it disappears. 
                //    //We just want to continue.
            }
            catch (NoSuchElementException)
            {
                //    //Do nothing if we cannot find the ajax loader.  In theory, this shouldn't hit because we're just checking if displayed, however
                //    //it has hit, so we're catching the exception. We haven't found the specific circumstances where it does hit.
            }
        }
    

        /// <summary>
        /// This function checks for the ajax loading image and waits until it disappears. 
        /// </summary>
        /// <param name="by">Locator to find ajax element</param>
        public void WaitForAjax(By by)
        {
            TestRun.LogComment("Waiting for ajax loading...");

            var stopwatch = new Stopwatch();

            //sleep for a second, just to let things settle and the ajax spinner to load. May need to increase this if ajax loading takes a long time
            Thread.Sleep(TimeSpan.FromSeconds(1));

            bool ajaxFound = false;  //Using this boolean so that we only detect 1 type of ajax loader so that the code will run faster.  If we need to at a later time, we can remove this check if there are multiple ajax loaders on the same page.

            var timeOutPeriod = TimeSpan.FromSeconds(90);

            stopwatch.Start();

            try
            {
                //while the "wait" image is displayed, wait until it is done to continue
                //Loop and check every 100 millisecond
                while (ExistsAndDisplayed(by) && stopwatch.Elapsed < timeOutPeriod)
                {
                    ajaxFound = true;
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                //wait for another quarter second for everything to load and then continue
                if (ajaxFound)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(.25));
                    return;
                }
            }
            catch (StaleElementReferenceException)
            {
                //Do nothing if there is a stale element exception.  We don't care what happens to the ajax loader icon when it disappears. 
                //We just want to continue.
            }
            catch (NoSuchElementException)
            {
                //Do nothing if we cannot find the ajax loader.  In theory, this shouldn't hit because we're just checking if displayed, however
                //it has hit, so we're catching the exception. We haven't found the specific circumstances where it does hit.
            }
        }

        /// <summary>
        /// Wait for an element to display.
        /// </summary>
        /// <param name="by">Selenium's built in locator</param>
        /// <param name="searchAllFrames">If true, the script will search all frames for the object</param>
        /// <param name="timeout">Timeout period in seconds (default value is the timeout specified in settings)</param>
        /// <returns>
        /// True if object is displayed
        /// False if object is not displayed within the timeout period
        /// </returns>
        /// 
        public bool WaitForObject(By by, double timeout = 0.0)
        {
            // if it's 0 then it wasn't specified in params, use the runtime value instead
            if (timeout == 0.0)
            {
                timeout = 60.0;
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Wait for object to appear
            do
            {
                if (ExistsAndDisplayed(by))
                {
                    return true;
                }
                else
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }

            } while (stopwatch.Elapsed.TotalSeconds < timeout);

            // if we get here, we didn't find it
            return false;
        }

        /// <summary>
        /// Checks if an element exists and is displayed
        /// </summary>
        /// <param name="driver">Instance of webdriver</param>
        /// <param name="by">Element locator</param>
        /// <returns>Returns true only if  the element exists and is displayed</returns>
        public bool ExistsAndDisplayed(By by)
        {
            if (Exists(by))
            {
                return Driver.FindElement(by).Displayed;
            }

            //
            return false;
        }

        /// <summary>
        /// Determines if an object exists
        /// </summary>
        /// <param name="driver">Webdriver</param>
        /// <param name="options">Interactions options</param>
        /// <param name="by">locator for object</param>
        /// <returns>true if object is found, else return false</returns>
        public bool Exists(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            //if element is not found, we're ok with it and return false
            catch (NotFoundException)
            {
                return false;
            }
        }
    }
}
