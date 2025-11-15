using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;

namespace LaerdalLLEAPTests.Utilities
{
    /// <summary>
    /// Waits for a window with the specified name and switches to it
    /// </summary>
    public static class WindowSwitcher
    {
        public static void SwitchToWindow(WindowsDriver<WindowsElement> driver, string windowName, int timeoutSecs = 10)
        {
            var startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime).TotalSeconds < timeoutSecs)
            {
                foreach (var handle in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(handle);

                    string currentWindowName = GetWindowName(driver);

                    if (currentWindowName != null &&
                        currentWindowName.Contains(windowName, StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }
                }
                Thread.Sleep(500);
            }
            
            throw new TimeoutException($"Window containing '{windowName}' not found within {timeoutSecs} seconds");
        }

        private static string GetWindowName(WindowsDriver<WindowsElement> driver)
        {
            if (!string.IsNullOrEmpty(driver.Title))
                return driver.Title;
            
            string[] xpaths = {
                "//Window[@Name]",
                "//Window",
                "//Pane//Window",
                "//*[@LocalizedControlType='window']"
            };
            
            foreach (var xpath in xpaths)
            {
                try
                {
                    var windowElement = driver.FindElement(By.XPath(xpath));
                    string name = windowElement.GetAttribute("Name");
                    if (!string.IsNullOrEmpty(name))
                        return name;
                }
                catch
                {
                    continue;
                }
            }
            
            return null;
        }

        public static void WaitForNewWindow(WindowsDriver<WindowsElement> driver, int originalWindowCount, int timeoutSeconds = 10)
        {
            var startTime = DateTime.Now;
            while (DateTime.Now - startTime < TimeSpan.FromSeconds(timeoutSeconds))
            {
                if (driver.WindowHandles.Count > originalWindowCount)
                {
                    return;
                }
                Thread.Sleep(500);
            }
    
            throw new TimeoutException($"New window did not appear within {timeoutSeconds} seconds");
        }
    }
}