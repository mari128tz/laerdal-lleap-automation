using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System.Threading;
using System.Linq;
using OpenQA.Selenium.Interactions;

namespace LaerdalLLEAPTests.Pages
{
    public class RunningSession
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        
        public RunningSession(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }
        
        //Step 12: For the Eyes control, select the "Closed" option
        public void SelectEyeState_Closed()
        {
            Thread.Sleep(2000);
            var eyesDropdown = _driver.FindElement(By.XPath("//*[@AutomationId='EyesComboBox']"));
            eyesDropdown.Click();
            
            Thread.Sleep(1000);
            var closedOption = _driver.FindElement(By.Name("Closed"));
            closedOption.Click();
        }
        
        //Step 13: For the Lung compliance, change the value to the specified percentage
        public void SetLungCompliance()
        {
            Thread.Sleep(2000);

            var slider = _driver.FindElement(By.XPath("//*[contains(@Name, 'lung compliance') or contains(@HelpText, 'lung compliance') or contains(@AutomationId, 'lung compliance')]"));
            slider.Click();
        }
        
        //Step 14: On the Patient monitor, click on the HR value and change it to the specified value
        public void SetHR(int hrValue)
        {
            Thread.Sleep(2000);
            
            // Click HR element to open modal
            var hrElement = _driver.FindElement(By.XPath("//*[@AutomationId='11']"));
            hrElement.Click();
            
            Thread.Sleep(2000);
            
            var textBox = _driver.FindElement(By.XPath("//*[@AutomationId='2093']"));
            textBox.Click();
            textBox.Clear();
            textBox.SendKeys(hrValue.ToString());
            
            // Confirm with OK button
            var okButton = _driver.FindElement(By.Name("OK"));
            okButton.Click();
        }
        
        //Step 15: For the Voices, select the Coughing and play it once
        public void SelectVocals_Coughing()
        {
            Thread.Sleep(1000);
            
            // Find and click the Coughing tree item
            var coughingItem = _driver.FindElement(By.Name("Coughing"));
            coughingItem.Click();
            
        }

        public void PlaySelectedVocals()
        {
            // Find and click the Play button by AutomationId
            var playVocals  = _driver.FindElement(By.XPath("//*[@AutomationId='PlayButton']"));
            playVocals.Click();
        }
        
        public void CloseApplicationWithX()
        {
            var closeButton = _driver.FindElement(By.XPath("//*[@AutomationId='Close']"));
            closeButton.Click();
            Thread.Sleep(3000);
        }

        #region Verifications

        public bool IsEyeStateClosed(WindowsDriver<WindowsElement> driver)
        {
            if (_driver.FindElement(By.XPath("//*[@AutomationId='EyesComboBox']")).Text == "Closed")
                return true;
            return false;
        }

        public bool IsHR100(WindowsDriver<WindowsElement> driver)
        {
            var hrElement = _driver.FindElement(By.XPath("//*[@AutomationId='11']"));
            hrElement.Click();
            
            Thread.Sleep(2000);
            
            var textBox = _driver.FindElement(By.XPath("//*[@AutomationId='2093']"));
            var okButton = _driver.FindElement(By.Name("OK"));
            if (textBox.Text == "100")
            {
                okButton.Click();
                return true;
            }
            okButton.Click();   
            return false;
        }

        public bool IsCoughingSelected(WindowsDriver<WindowsElement> driver)
        {
            if (_driver.FindElement(By.Name("Coughing")).Selected)
                return true;
            return false;
        }

        public bool IsVocalPlaying(WindowsDriver<WindowsElement> driver)
        {
            if (_driver.FindElement(By.XPath("//*[@AutomationId='StopButton']")).Enabled)
                return true;
            return false;
        }

        public bool DidAppClose(WindowsDriver<WindowsElement> driver)
        {
            return _driver.WindowHandles.Count == 0;
        }
        #endregion
        
        
    }
}