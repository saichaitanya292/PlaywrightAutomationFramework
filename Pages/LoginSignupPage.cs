using Microsoft.Playwright;

namespace PlaywrightAutomation.Pages
{
    public class LoginSignupPage
    {
        private readonly IPage _page;

        public LoginSignupPage(IPage page)
        {
            _page = page;
        }

        private ILocator SignupContainer =>
            _page.Locator("div.signup-form");

        private ILocator SignupName =>
            SignupContainer.Locator("input[data-qa='signup-name']");

        private ILocator SignupEmail =>
            SignupContainer.Locator("input[data-qa='signup-email']");

        private ILocator SignupButton =>
            SignupContainer.Locator("button[data-qa='signup-button']");

        public async Task Navigate()
        {
            await _page.GotoAsync("https://automationexercise.com/login");

            // Wait until Signup form is visible
            await SignupContainer.WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible
            });
        }

        public async Task EnterSignupDetails(string name, string email)
        {
            // Wait for fields before interacting
            await SignupName.WaitForAsync();
            await SignupName.FillAsync(name);

            await SignupEmail.WaitForAsync();
            await SignupEmail.FillAsync(email);

            await SignupButton.WaitForAsync();
            await SignupButton.ClickAsync();
        }
    }
}
