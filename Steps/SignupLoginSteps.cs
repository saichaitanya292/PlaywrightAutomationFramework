using Microsoft.Playwright;
using Reqnroll;
using System.Linq;
using FluentAssertions;
using PlaywrightAutomation.Utilities;
using PlaywrightAutomation.Pages;
using PlaywrightAutomation.Reporting;

namespace PlaywrightAutomation.Steps
{
    [Binding]
    public class SignupLoginSteps
    {
        private readonly IPage _page;
        private readonly LoginSignupPage _loginPage;
        private readonly AccountRegistrationPage _registrationPage;

        private string _email = string.Empty;
        private string _password = "Test@123";
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;

        public SignupLoginSteps(ScenarioContext scenarioContext)
        {
            _page = (IPage)scenarioContext["Page"];
            _loginPage = new LoginSignupPage(_page);
            _registrationPage = new AccountRegistrationPage(_page);
        }

        [Given(@"User navigates to signup page")]
        public async Task GivenUserNavigatesToSignupPage()
        {
            ExtentManager.GetTest().Info("Navigating to signup page");

            await _loginPage.Navigate();
        }

        [When(@"User enters name and email")]
        public async Task WhenUserEntersNameAndEmail()
        {
            _firstName = RandomDataGenerator.GetRandomFirstName();
            _lastName = RandomDataGenerator.GetRandomLastName();
            _email = RandomDataGenerator.GetRandomEmail();

            ExtentManager.GetTest().Info($"Generated First Name: {_firstName}");
            ExtentManager.GetTest().Info($"Generated Last Name: {_lastName}");
            ExtentManager.GetTest().Info($"Generated Email: {_email}");

            await _loginPage.EnterSignupDetails(_firstName, _email);
        }

        [When(@"User completes account registration")]
        public async Task WhenUserCompletesRegistration()
        {
            ExtentManager.GetTest().Info("Completing account registration");

            await _registrationPage.CompleteRegistration(
                _password,
                _firstName,
                _lastName,
                RandomDataGenerator.GetRandomAddress(),
                "Telangana",
                "Hyderabad",
                RandomDataGenerator.GetRandomZipCode(),
                RandomDataGenerator.GetRandomMobileNumber());
        }

        [Then(@"User should be logged in successfully")]
        public async Task ThenUserShouldBeLoggedInSuccessfully()
        {
            ExtentManager.GetTest().Info("Verifying user login status");

            var links = await _registrationPage.GetAllLinks();

            var isLoggedIn = links.Any(text => text.Contains("Logged in as"));

            isLoggedIn
                .Should()
                .BeTrue("user should be logged in successfully");

            ExtentManager.GetTest().Pass("User logged in successfully");
        }
    }
}
