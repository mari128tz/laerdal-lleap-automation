using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;

namespace LaerdalLLEAPTests.Pages
{
    public class HomePage
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";

        public HomePage(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        //Clicks "Instructor Application" and waits for the Startup window
        public WindowsDriver<WindowsElement> ClickInstructorApplication()
        {
            var instructorApp = _driver.FindElement(By.XPath("//Button[.//*[@AutomationId='MainImage']]"));
            instructorApp.Click();
            
            // Connect to the LLEAP process and return the new driver
            return ConnectToLLEAPProcess();
        }
        
        private WindowsDriver<WindowsElement> ConnectToLLEAPProcess()
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Root");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("platformName", "Windows");
            
            using (var desktopDriver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options))
            {
                var startupWindow = desktopDriver.FindElement(By.Name("Startup"));
                string startupWindowHandle = startupWindow.GetAttribute("NativeWindowHandle");
                startupWindowHandle = int.Parse(startupWindowHandle).ToString("x");
                
                // Connect directly to this window
                var lleapOptions = new AppiumOptions();
                lleapOptions.AddAdditionalCapability("appTopLevelWindow", startupWindowHandle);
                lleapOptions.AddAdditionalCapability("deviceName", "WindowsPC");
                lleapOptions.AddAdditionalCapability("platformName", "Windows");
                
                var instructorAppDriver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), lleapOptions);
                instructorAppDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                
                return instructorAppDriver;
            }
        }
    }
}