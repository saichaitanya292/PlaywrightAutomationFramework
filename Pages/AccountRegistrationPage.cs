using Microsoft.Playwright;

namespace PlaywrightAutomation.Pages
{
    public class AccountRegistrationPage
    {
        private readonly IPage _page;

        public AccountRegistrationPage(IPage page)
        {
            _page = page;
        }

        public async Task CompleteRegistration(
            string password,
            string firstName,
            string lastName,
            string address,
            string state,
            string city,
            string zipcode,
            string mobile)
        {
            await _page.ClickAsync("#id_gender1");
            await _page.FillAsync("#password", password);

            await _page.SelectOptionAsync("#days", "1");
            await _page.SelectOptionAsync("#months", "1");
            await _page.SelectOptionAsync("#years", "1995");

            await _page.FillAsync("#first_name", firstName);
            await _page.FillAsync("#last_name", lastName);
            await _page.FillAsync("#address1", address);
            await _page.SelectOptionAsync("#country", "India");
            await _page.FillAsync("#state", state);
            await _page.FillAsync("#city", city);
            await _page.FillAsync("#zipcode", zipcode);
            await _page.FillAsync("#mobile_number", mobile);

            await _page.ClickAsync("button[data-qa='create-account']");
            await _page.ClickAsync("a[data-qa='continue-button']");
        }

        public async Task<IReadOnlyList<string>> GetAllLinks()
        {
            return await _page.Locator("a").AllInnerTextsAsync();
        }
    }
}
