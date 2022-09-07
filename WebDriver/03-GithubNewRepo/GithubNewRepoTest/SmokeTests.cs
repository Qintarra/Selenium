using GitHubAutomation.Steps;
using NUnit.Framework;

namespace github_auto
{
    public class SmokeTests
    {
        private readonly Steps steps = new Steps();
        private const string USERNAME = "YourUsername"; // placeholder, enter your github username
        private const string PASSWORD = "ChangeMe"; // placeholder, enter your github password
        private const int REPOSITORY_RANDOM_POSTFIX_LENGTH = 6;

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [Test]
        public void OneCanLoginGithub()
        {
            steps.LoginGithub(USERNAME, PASSWORD);
            Assert.That(steps.GetLoggedInUserName(), Is.EqualTo(USERNAME));
        }

        [Test]
        public void OneCanCreateProject()
        {
            steps.LoginGithub(USERNAME, PASSWORD);
            string repositoryName = Steps.GenerateRandomRepositoryNameWithCharLength(REPOSITORY_RANDOM_POSTFIX_LENGTH);
            steps.CreateNewRepository(repositoryName, "auto-generated test repo");
            Assert.That(steps.GetCurrentRepositoryName(), Is.EqualTo(repositoryName));
        }

        [TearDown]
        public void Cleanup()
        {
            Steps.CloseBrowser();
        }
    }
}