using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using LaerdalLLEAPTests.Utilities;
using LaerdalLLEAPTests.Pages;
using OpenQA.Selenium;
using System;

namespace LaerdalLLEAPTests
{
    [TestFixture]
    public class BaseTest
    {
        protected WindowsDriver<WindowsElement> Driver;
        protected WindowsDriver<WindowsElement> InstructorAppDriver;
        
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        
        protected HomePage HomePage;
        protected InstructorAppBoot InstructorApp;
        
        [SetUp]
        public void TestSetup()
        {
            var options = new AppiumOptions();
            
            options.AddAdditionalCapability("app", @"C:\Program Files (x86)\Laerdal Medical\Laerdal Simulation Home\LaunchPortal.exe");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("platformName", "Windows");
            options.AddAdditionalCapability("ms:waitForAppLaunch", "15");
            
            Driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);
            
            HomePage = new HomePage(Driver);
            InstructorApp = null;
        }

        [TearDown]
        public void TearDown()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            string testStatus = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string errorMessage = TestContext.CurrentContext.Result.Message;
                TestLogger.Log(testName, $"✗ TEST FAILED: {errorMessage}");
                
                if (Driver != null)
                {
                    ScreenshotHelper.TakeScreenshot(Driver, testName);
                }
            }
            else
            {
                TestLogger.Log(testName, "✓ TEST PASSED");
            }
            
            InstructorAppDriver?.Dispose();
            Driver?.Dispose();
            Driver = null;
            InstructorAppDriver = null;
        }
    }
}