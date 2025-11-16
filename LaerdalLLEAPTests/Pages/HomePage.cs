using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System.IO;

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
            Thread.Sleep(5000);
            // Connect to the LLEAP process and return the new driver
            return ConnectToLLEAPProcess();
        }

        public void RightClickHelp()
        {
            InputHelper.RightClick(_driver, By.XPath("//Button[@Name='Help']//Image[@AutomationId='MainImage']"));
        }
        
        public void ClickCollectClientLogFiles()
        {
            var collectLogsOption = _driver.FindElement(By.Name("Collect client log files"));
            collectLogsOption.Click();
        }

        public int LogCount()
        {
            return Directory.GetFiles(@"C:\Users\Public\Documents\Laerdal Report Zipped").Length;
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
                instructorAppDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                
                return instructorAppDriver;
            }
            
        }
     
        
        #region Verifications
        public WindowsElement IsInstructorAppRunning(WindowsDriver<WindowsElement> instructorAppDriver)
        {
            return instructorAppDriver.FindElement(By.Name("Add license later"));
        }
        public WindowsElement WasHelpButtonRightClicked()
        {
            return _driver.FindElement(By.Name("Collect client log files"));
        }
        public bool IsLogViewerWindowOpen()
        {
            Thread.Sleep(3000);
            var windows = _driver.FindElements(By.XPath("//Window[starts-with(@Name, 'Select C:\\\\Program Files (x86)\\\\Laerdal Medical\\\\Laerdal Simulation Home\\\\ClientLogCollect')]"));
            return windows.Count > 0 && windows[0].Displayed;
        }
        
        #endregion
        
    }
}