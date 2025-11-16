using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

public static class InputHelper
{
    public static void RightClick(WindowsDriver<WindowsElement> driver, WindowsElement element)
    {
        new Actions(driver)
            .ContextClick(element)
            .Perform();
    }

    public static void RightClick(WindowsDriver<WindowsElement> driver, By locator)
    {
        var element = driver.FindElement(locator);
        RightClick(driver, element);
    }
    
}