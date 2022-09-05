using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace EmailSendTest
{
    public class Tests
    {
        private IWebDriver _driver;

        private readonly By _loginField = By.ClassName("_2yPTK9xQ");
        private readonly By _passwordField = By.Name("password");
        private readonly By _continueButton = By.CssSelector(".Ol0-ktls");
        private readonly By _composeButton = By.XPath("//button[@class='button primary compose']");
        private readonly By _sendmsgTo = By.Name("toFieldInput");
        private readonly By _sendmsgSubject = By.Name("subject");
        private readonly By _messageBody = By.Id("mce_0_ifr");
        private readonly By _sending = By.XPath("//button[@class='button primary send']");
        private readonly By _confirmSending = By.ClassName("sendmsg__ads-ready");

        // Need to change the user data before a test run
        private readonly string user1email = "testuser01@ukr.net";
        private readonly string user2login = "testuser02";
        private readonly string user2password = "changeMe";

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://accounts.ukr.net/login?lang=en");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void SendingMessage()
        {
            var SearchLoginField = _driver.FindElement(_loginField);
            SearchLoginField.SendKeys(user2login);

            var SearchPasswordField = _driver.FindElement(_passwordField);
            SearchPasswordField.SendKeys(user2password);

            WebDriverWait waitForSearchInput = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var SearchButtonPressing = waitForSearchInput.Until(d => d.FindElement(_continueButton));
            SearchButtonPressing.Submit();

            WebDriverWait waitForLogin = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var Compose = waitForLogin.Until(d => d.FindElement(_composeButton));
            Compose.Click();

            var SendMessageFormTitle = _driver.FindElement(_sendmsgTo);
            SendMessageFormTitle.SendKeys(user1email);

            var SendMessageFormSubject = _driver.FindElement(_sendmsgSubject);
            SendMessageFormSubject.SendKeys("test_message");

            WebDriverWait waitMessageText = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var SendMessageContent = waitMessageText.Until(d => d.FindElement(_messageBody));
            SendMessageContent.SendKeys("Lorem ipsum dolor sit amet");

            var Send = _driver.FindElement(_sending);
            Send.Click();

            WebDriverWait waitSendingConfirmed = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var messageSent = waitSendingConfirmed.Until(ExpectedConditions.ElementExists(_confirmSending));

            Assert.That(messageSent.Enabled);
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}