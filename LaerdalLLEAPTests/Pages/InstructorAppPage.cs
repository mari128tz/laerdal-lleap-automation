using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace LaerdalLLEAPTests.Pages
{
    //This class handles the Instructor Application screens
    public class InstructorAppPage
    {
        private readonly AppiumDriver _driver;
        
        public InstructorAppPage(AppiumDriver driver)
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
            var localComputerButton = _driver.FindElement(By.Name("Local Computer"));
            localComputerButton.Click();
        }

        //Clicks the "SimMan 3G Plus" tile [Test #1 - Step 5]
        public void ClickSimMan3GPlus()
        {
            var simMan3GPlusButton = _driver.FindElement(By.Name("SimMan 3G Plus"));
            simMan3GPlusButton.Click();
        }
        
        //Clicks "Manual Mode" [Test #1 - Step 6]
        public void ClickManualMode()
        {
            var manualModeButton = _driver.FindElement(By.Name("Manual Mode"));
            manualModeButton.Click();
        }

        //Clicks "Healthy Patient" [Test #1 - Step 8]
        public void ClickTheme_HealthyPatient()
        {
            var healthyPatientThemeButton = _driver.FindElement(By.Name("Healthy Patient"));
            healthyPatientThemeButton.Click();
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
            var startSessionButton = _driver.FindElement(By.Name("Start Session"));
            startSessionButton.Click();
        }
        
        //Maximizes the window
        public void MaximizeLLEAP()
        {
            _driver.Manage().Window.Maximize();
        }
    }
}

