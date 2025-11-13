using NUnit.Framework;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using LaerdalLLEAPTests.Utilities;
using LaerdalLLEAPTests.Pages;
using OpenQA.Selenium;

namespace LaerdalLLEAPTests
{
    [TestFixture]
    public class BaseTest
    {
        protected WindowsDriver<WindowsElement> Driver;
        
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        
        protected SimulationHomePage HomePage;
        protected InstructorAppPage InstructorApp;
        
        [SetUp]
        public void TestSetup(){
            try
            {
                Console.WriteLine("Starting Laerdal Simulation Home application...");
                
                //WinAppDriver - LLEAP connection
                var options = new AppiumOptions();
                
                //App to launch - your specific path
                options.AddAdditionalCapability("app", @"C:\Program Files (x86)\Laerdal Medical\Laerdal Simulation Home\LaunchPortal.exe");
                //PC name
                options.AddAdditionalCapability("deviceName", "WindowsPC");
                //OS
                options.AddAdditionalCapability("platformName", "Windows");
                //Give app time to launch
                options.AddAdditionalCapability("ms:waitForAppLaunch", "15");
                
                //Launch LLEAP
                Driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);
                
                //Grace period: The test will wait up to 10 seconds for UI elements to appear
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                
                // Create page objects
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
                {
                    if (Driver != null)
                    {
                        ScreenshotHelper.TakeScreenshot(Driver, TestContext.CurrentContext.Test.Name);
                    }
                    else
                    {
                        Console.WriteLine("Cannot take screenshot - Driver is null");
                    }
                }
                
            }
            catch (Exception ex)
            {
                //If Teardown fails, it's logged and the test doesn't crash
                Console.WriteLine($"Error during teardown: {ex.Message}");
            }
            finally
            {
                //closes LLEAP and releases the driver from memory
                Driver?.Dispose();
                Driver = null;
            }
        }
    }
}