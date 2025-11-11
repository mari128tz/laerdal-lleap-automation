using System;
using System.Drawing;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace LaerdalLLEAPTests.Utilities;

public static class ScreenshotHelper
{
    /*MAIN METHOD: Takes screenshot and saves it
    *Parameters:
    * 1. driver
     2. test name*/
    
    public static void TakeScreenshot(AppiumDriver driver, string testName)
    {
        
        // try-catch to prevent the test from crashing due to screenshot errors
        try
        {
            //1. Capture the screen
            var screenshot = driver.GetScreenshot();
            
            //2. Create an easily identifiable file name
            // Format: "TestName_20231201_143025.png"
            var fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            
            //3. Save the screenshot
            string fullPath = Path.Combine(GetScreenshotDirectory(), fileName);
            screenshot.SaveAsFile(fullPath);
            
            //4. **DEBUG** Log screenshot name and save location
            Console.WriteLine($"Screenshot {fileName} saved to {fullPath}");
            
        }
        catch (Exception ex)
        {
            Console.WriteLine("$Failed to take screenshot");
        }
    }

    //Method to handle saving location for the screenshots
    private static string GetScreenshotDirectory()
    {
        // Create the folder path: CurrentDirectory\TestResults\Screenshots
        string directory = Path.Combine(Directory.GetCurrentDirectory(), "TestResults", "Screenshots");
        
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        
        //Return the folder path
        return directory;
    }
}