using OpenQA.Selenium;
using System;

namespace GitHubAutomation.Pages
{
    public class LoginPage
    {
        private const string BASE_URL = "https://github.com/login";

        private readonly IWebDriver driver;

        private IWebElement InputLogin => driver.FindElement(By.Id("login_field"));

        private IWebElement InputPassword => driver.FindElement(By.Id("password"));

        private IWebElement ButtonSubmit => driver.FindElement(By.XPath("//input[@value='Sign in']"));

        private IWebElement LinkLoggedInUser => driver.FindElement(By.XPath("//meta[@name='user-login']"));
      

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Login Page opened");
        }

        public void Login(string username, string password)
        {
            InputLogin.SendKeys(username);
            InputPassword.SendKeys(password);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ButtonSubmit.Submit();
        }

        public string GetLoggedInUserName()
        {
            return LinkLoggedInUser.GetAttribute("content");
        }
    }
}