using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace GitHubAutomation.Driver
{
    public class DriverInstance
    {
        private static IWebDriver driver;

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(10));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}