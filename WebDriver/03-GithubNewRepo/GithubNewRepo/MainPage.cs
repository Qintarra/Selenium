using OpenQA.Selenium;
using System;

namespace GitHubAutomation.Pages
{
    public class MainPage
    {
        private const string BASE_URL = "http://www.github.com/";

        private readonly IWebDriver driver;

        private IWebElement ButtonCreateNew => driver.FindElement(By.XPath("//summary[@aria-label='Create new…']"));

        private IWebElement LinkNewRepository => driver.FindElement(By.XPath("//a[normalize-space()='New repository']"));

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void ClickOnCreateNewRepositoryButton()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ButtonCreateNew.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LinkNewRepository.Click();
        }
    }
}