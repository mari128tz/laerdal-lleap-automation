using NUnit.Framework;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using LaerdalLLEAPTests.Utilities;
using LaerdalLLEAPTests.Pages;

namespace LaerdalLLEAPTests
{
    [TestFixture]
    public class BaseTest
    {
        protected AppiumDriver Driver;
        
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        
        protected SimulationHomePage HomePage;
        protected InstructorAppPage InstructorApp;
        [SetUp]
        public void TestSetup(){
            try
            {
                //WinAppDriver - LLEAP connection
                var options = new AppiumOptions();
                
                //App to launch
                options.App = @"{7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E}\Laerdal Medical\Laerdal Simulation Home\LaunchPortal.exe";
                //PC name
                options.DeviceName = "WindowsPC";
                //OS
                options.PlatformName = "Windows";
                
                //Launch LLEAP
                Driver = new WindowsDriver(new Uri(WindowsApplicationDriverUrl), options);
                
                //Grace period: The test will wait up to 10 seconds for UI elements to appear
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                
                HomePage = new SimulationHomePage(Driver);
                InstructorApp = new InstructorAppPage(Driver);
                
                //If LLEAP starts successfully
                Console.WriteLine("Application started successfully.");
            }
            catch (Exception ex)
            {
                //If LLEAP fails to start
                Console.WriteLine($"Failed to start application. Error: {ex.Message}");
                throw;
            }
        }

        [TearDown] //Runs automatically after each test: Cleanup, Evidence Collection and Test Isolation
        public void TearDown()
        {
            try
            {
                //If test fails, takes a screenshot
                if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
                    ScreenshotHelper.TakeScreenshot(Driver, TestContext.CurrentContext.Test.Name);
                
            }
            catch (Exception ex)
            {
                //If Teardown fails, it's logged and the test doesn't crash
                Console.WriteLine($"Error during teardown: {ex.Message}");
                throw;
            }
            finally
            {
                //closes LLEAP and releases the driver from memory
                Driver?.Dispose();
            }
        }
    }
}

