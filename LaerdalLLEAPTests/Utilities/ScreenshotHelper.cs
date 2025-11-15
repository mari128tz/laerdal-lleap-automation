using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace LaerdalLLEAPTests.Utilities
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(WindowsDriver<WindowsElement> driver, string testName)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string fullPath = Path.Combine(GetScreenshotDirectory(), fileName);
                screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to take screenshot: {ex.Message}");
            }
        }

        private static string GetScreenshotDirectory()
        {
            string directory = Path.Combine(Directory.GetCurrentDirectory(), "TestResults", "Screenshots");
            
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            
            return directory;
        }
    }
}