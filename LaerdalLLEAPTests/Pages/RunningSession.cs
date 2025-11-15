using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System.Threading;
using System.Linq;

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
        public void SetLungCompliance(int percentage)
        {
            int[] allowedValues = { 0, 33, 67, 100 };
            if (!allowedValues.Contains(percentage))
                throw new ArgumentException($"Percentage must be one of: {string.Join(", ", allowedValues)}");
            
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
            
            // Set value in modal using text box
            var textBox = _driver.FindElement(By.XPath("//*[@AutomationId='2093']"));
            textBox.Click();
            textBox.Clear();
            textBox.SendKeys(hrValue.ToString());
            
            // Confirm with OK button
            var okButton = _driver.FindElement(By.Name("OK"));
            okButton.Click();
        }
        
        //Step 15: For the Voices, select the Coughing and play it once
        public void PlayVocals_Coughing()
        {
            Thread.Sleep(1000);
            
            // Find and click the Coughing tree item
            var coughingItem = _driver.FindElement(By.Name("Coughing"));
            coughingItem.Click();
            
            
            // Find and click the Play button by AutomationId
            var playButton = _driver.FindElement(By.XPath("//*[@AutomationId='PlayButton']"));
            playButton.Click();
            
            // Wait for sound to play
            Thread.Sleep(2000);
        }
    }
}