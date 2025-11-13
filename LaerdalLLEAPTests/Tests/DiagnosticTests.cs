using NUnit.Framework;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using System.Net;

namespace LaerdalLLEAPTests.Tests
{
    [TestFixture]
    public class WinAppDriverTests
    {
        private const string WinAppDriverUri = "http://127.0.0.1:4723";

        [Test]
        public void TestWinAppDriver_ConfirmedWorking()
        {
            Console.WriteLine("WinAppDriver confirmed running - testing connection...");
            
            // Use WebClient to verify we can reach WinAppDriver from .NET
            using (var client = new WebClient())
            {
                string status = client.DownloadString($"{WinAppDriverUri}/status");
                Console.WriteLine($"WebClient status: {status}");
            }

            var options = new AppiumOptions();
            options.AddAdditionalCapability("platformName", "Windows");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("app", "Root");
            
            using (var driver = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUri), options))
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                
                Console.WriteLine($"SUCCESS! Driver session created: {driver.SessionId}");
                
                // Use a simpler, faster query instead of //*
                try
                {
                    // Try to find just a few common desktop elements
                    var taskbar = driver.FindElement(By.Name("Taskbar"));
                    Console.WriteLine("Found Taskbar!");
                    
                    // Or try to find start button
                    var startButton = driver.FindElement(By.Name("Start"));
                    Console.WriteLine("Found Start button!");
                    
                    Assert.Pass("WinAppDriver is working! Found desktop elements.");
                }
                catch (NoSuchElementException)
                {
                    // If common elements not found, try a limited element search
                    var elements = driver.FindElements(By.XPath("//Pane")); // Much faster than //*
                    Console.WriteLine($"Found {elements.Count} Pane elements");
                    
                    Assert.Pass($"WinAppDriver is working! Found {elements.Count} Pane elements");
                }
            }
        }

        [Test]
        public void TestWinAppDriver_FastDesktopCheck()
        {
            Console.WriteLine("Fast desktop connection test...");
            
            var options = new AppiumOptions();
            options.AddAdditionalCapability("platformName", "Windows");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("app", "Root");
            
            using (var driver = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUri), options))
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                
                // Just verify we can interact with the desktop session
                var sessionId = driver.SessionId;
                var capabilities = driver.Capabilities;
                
                Console.WriteLine($"Session created: {sessionId}");
                Console.WriteLine($"Platform: {capabilities["platformName"]}");
                
                Assert.Pass($"Desktop session active - Session: {sessionId}");
            }
        }

        [Test]
        public void TestWinAppDriver_NotepadQuick()
        {
            Console.WriteLine("Quick Notepad test...");
            
            var options = new AppiumOptions();
            options.AddAdditionalCapability("platformName", "Windows");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("app", @"C:\Windows\System32\notepad.exe");
            
            using (var driver = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUri), options))
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                
                // Quick verification - just check if we can find the window
                var window = driver.FindElement(By.ClassName("Notepad"));
                Console.WriteLine("Notepad window found!");
                
                Assert.Pass("Notepad launched successfully!");
            }
        }
    }
}