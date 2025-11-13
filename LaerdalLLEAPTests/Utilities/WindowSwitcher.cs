using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;

namespace LaerdalLLEAPTests.Utilities
{
    /// Waits for a window with the specified name and switches to it
    public static class WindowSwitcher
    {
        public static void SwitchToWindow(WindowsDriver<WindowsElement> driver, string windowName, int timeoutSecs = 10)
        {
            Console.WriteLine($"Waiting for window: '{windowName}' (timeout: {timeoutSecs}s)");
            
            var startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < timeoutSecs)
            {
                foreach (var handle in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(handle);

                    try
                    {
                        string currentWindowName = GetWindowName(driver);

                        if (currentWindowName != null &&
                            currentWindowName.Contains(windowName, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"✓ Switched to window: '{currentWindowName}'");
                            return;
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error checking window: {ex.Message}");
                    }
                }
                Thread.Sleep(500); // Wait half second before retrying
            }
            
            throw new TimeoutException($"Window containing '{windowName}' not found");
        }
        private static string GetWindowName(WindowsDriver<WindowsElement> driver)
        {
            try
            {
                // Try to get window title first
                var title = driver.Title;
                if (!string.IsNullOrEmpty(title)) 
                    return title;

                // Try to find the main window element and get its name
                var windowElement = driver.FindElement(By.XPath("//Window"));
                return windowElement.GetAttribute("Name") ?? windowElement.GetAttribute("ClassName");
            }
            catch
            {
                return null;
            }
        }
        public static void WaitForNewWindow(WindowsDriver<WindowsElement> driver, int originalWindowCount, int timeoutSeconds = 10)
        {
            Console.WriteLine($"Waiting for new window (current: {originalWindowCount})...");
    
            var startTime = DateTime.Now;
            while (DateTime.Now - startTime < TimeSpan.FromSeconds(timeoutSeconds))
            {
                if (driver.WindowHandles.Count > originalWindowCount)
                {
                    Console.WriteLine($"✓ New window detected! Total windows: {driver.WindowHandles.Count}");
                    return;
                }
                Thread.Sleep(500);
            }
    
            throw new TimeoutException($"New window did not appear within {timeoutSeconds} seconds");
        }

    }
}

