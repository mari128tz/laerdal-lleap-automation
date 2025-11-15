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
            
            //App to launch - your specific path
            options.AddAdditionalCapability("app", @"C:\Program Files (x86)\Laerdal Medical\Laerdal Simulation Home\LaunchPortal.exe");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("platformName", "Windows");
            options.AddAdditionalCapability("ms:waitForAppLaunch", "15");
            
            //Launch LLEAP
            Driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);
            
            //Grace period: The test will wait up to 5 seconds for UI elements to appear
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
            // Create page objects with the main driver
            HomePage = new HomePage(Driver);
            
            // InstructorApp will be created later with the InstructorAppDriver
            InstructorApp = null;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                if (Driver != null)
                {
                    ScreenshotHelper.TakeScreenshot(Driver, TestContext.CurrentContext.Test.Name);
                }
            }
            
            // Close both drivers
            InstructorAppDriver?.Dispose();
            Driver?.Dispose();
            Driver = null;
            InstructorAppDriver = null;
        }
    }
}