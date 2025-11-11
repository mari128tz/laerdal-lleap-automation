using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace LaerdalLLEAPTests.Pages
{
    public class SimulationHomePage
    {
        //Class for the Home Screen
        private readonly AppiumDriver _driver;

        public SimulationHomePage(AppiumDriver driver)
        {
            _driver = driver;
        }

        //Clicks "Instructor Application"
        public void ClickInstructorApplication()
        {
            var instructorApp = _driver.FindElement(By.Name("Instructor Application"));
            instructorApp.Click();
        }
    }
}