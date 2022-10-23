using OpenQA.Selenium;
using System;
using System.Threading;

namespace GitHubAutomation.Pages
{
    public class CreateNewRepositoryPage
    {
        private const string BASE_URL = "http://www.github.com/new";
        private readonly IWebDriver driver;

        private IWebElement InputRepositoryName => driver.FindElement(By.XPath("//input[@id='repository_name']"));

        private IWebElement InputRepositoryDescription => driver.FindElement(By.Id("repository_description"));

        private IWebElement ButttonCreate => driver.FindElement(By.XPath("//form[@id='new_repository']//button[@type='submit']"));

        private IWebElement LabelEmptyRepoRecommendations => driver.FindElement(By.ClassName("//h3/strong[text()='Quick setup']"));

        private IWebElement LinkCurrentRepository => driver.FindElement(By.XPath("//a[@data-pjax='#repo-content-pjax-container']"));

        public CreateNewRepositoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void CreateNewRepository(string repositoryName, string repositoryDescription)
        {
            InputRepositoryName.SendKeys(repositoryName);
            InputRepositoryDescription.SendKeys(repositoryDescription);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ButttonCreate.Click();

            Thread.Sleep(5000); // Can be removed. Just to look at the successfully created repo

        }

        public bool IsCurrentRepositoryEmpty()
        {
            return LabelEmptyRepoRecommendations.Displayed;
        }

        public string GetCurrentRepositoryName()
        {
            return LinkCurrentRepository.Text;
        }
    }
}
