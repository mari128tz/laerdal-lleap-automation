using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using LaerdalLLEAPTests.Utilities;
using System;
using System.Threading;

namespace LaerdalLLEAPTests.Pages
{
    public class SimulationHomePage
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        public SimulationHomePage(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        //Clicks "Instructor Application" and waits for the Startup window
        public void ClickInstructorApplication()
        {
            Console.WriteLine("Clicking Instructor Application...");
            
            var instructorApp = _driver.FindElement(By.Name("LLEAP - Instructor Application"));
            instructorApp.Click();
            
            Console.WriteLine("Clicked. Waiting for Startup window to appear...");
            
            // Instead of checking window handles, just wait and then try to find the Startup window
            // Give it more time to open
            Thread.Sleep(5000);
            
            // Now try to switch to the Startup window directly
            try
            {
                WindowSwitcher.SwitchToWindow(_driver, "Startup", 15); // Give it 15 seconds
                Console.WriteLine("✓ Successfully switched to Startup window");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to switch to Startup window: {ex.Message}");
                Console.WriteLine("Trying alternative approach...");
                
                // Alternative: Try to find the window by looking for its content
                TryAlternativeWindowSwitch();
            }
        }
        
        private void TryAlternativeWindowSwitch()
        {
            Console.WriteLine("Trying alternative window detection...");
            
            // Look for any window that contains the elements we expect in the Startup window
            var originalHandle = _driver.CurrentWindowHandle;
            
            foreach (var handle in _driver.WindowHandles)
            {
                _driver.SwitchTo().Window(handle);
                try
                {
                    // Check if this window has elements from the Startup window
                    var elements = _driver.FindElements(By.Name("Add license later"));
                    if (elements.Count > 0)
                    {
                        Console.WriteLine("✓ Found Startup window by content ('Add license later' button)");
                        return;
                    }
                    
                    elements = _driver.FindElements(By.Name("Local Computer"));
                    if (elements.Count > 0)
                    {
                        Console.WriteLine("✓ Found Startup window by content ('Local Computer' button)");
                        return;
                    }
                }
                catch
                {
                    // Continue to next window
                }
            }
            
            // If we get here, switch back to original and throw error
            _driver.SwitchTo().Window(originalHandle);
            throw new Exception("Could not find Startup window by any method");
        }
    }
}