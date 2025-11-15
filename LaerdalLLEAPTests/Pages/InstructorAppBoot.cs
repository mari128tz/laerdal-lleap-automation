using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using LaerdalLLEAPTests.Utilities;
using System.Threading;

namespace LaerdalLLEAPTests.Pages
{
    public class InstructorAppBoot
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        
        public InstructorAppBoot(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }
        
        //Clicks "Add license later" [Test #1 - Step 3]
        public void ClickAddLicenseLater()
        {
            var addLicenseLaterButton = _driver.FindElement(By.Name("Add license later"));
            addLicenseLaterButton.Click();
        }
        
        //Clicks the "Local Computer" tile [Test #1 - Step 4]
        public void ClickLocalComputer()
        {
            Thread.Sleep(4000);
            var localComputerButton = _driver.FindElement(By.Name("Local computer"));
            localComputerButton.Click();
        }

        //Clicks the "SimMan 3G Plus" tile [Test #1 - Step 5]
        public void ClickSimMan3GPlus()
        {
            var simMan3GPlusButton = _driver.FindElement(By.Name("SimMan 3G PLUS"));
            simMan3GPlusButton.Click();
        }
        
        //Clicks "Manual Mode" [Test #1 - Step 6]
        public void ClickManualMode()
        {
            Thread.Sleep(3000);
            var manualModeButton = _driver.FindElement(By.Name("Manual Mode"));
            manualModeButton.Click();
        }

        //Clicks "Healthy Patient" [Test #1 - Step 8]
        public void ClickTheme_HealthyPatient()
        {
            Thread.Sleep(3000);
            WindowSwitcher.SwitchToWindow(_driver, "Select theme", 10);
    
        
            var healthyPatient = _driver.FindElement(By.Name("Healthy patient"));
            healthyPatient.Click();
        
            Console.WriteLine("✓ Clicked second Healthy patient theme");
        }

        //Clicks "Ok" [Test #1 - Step 9]
        public void ClickSelectThemeOk()
        {
            var selectThemeOkButton = _driver.FindElement(By.Name("Ok"));
            selectThemeOkButton.Click();
        }
        
        //Clicks "Start Session" [Test #1 - Step 10]
        public void ClickStartSession()
        {
            Thread.Sleep(5000);
            WindowSwitcher.SwitchToWindow(_driver, "PAUSE", 10);
            
            var startSessionButton = _driver.FindElement(By.Name("Start session"));
            startSessionButton.Click();
        }
        
        //Maximizes the window
        public void MaximizeLLEAP()
        {
            _driver.Manage().Window.Maximize();
        }
        
        public void CloseApplicationWithX()
        {
            _driver.Close();
            Thread.Sleep(3000);
        }
    }
}