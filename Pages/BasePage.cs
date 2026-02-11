using Microsoft.Playwright;

namespace PlaywrightAutomation.Pages
{
    public class BasePage
    {
        protected readonly IPage Page;

        public BasePage(IPage page)
        {
            Page = page;
        }

        protected async Task WaitForVisibleAsync(ILocator locator)
        {
            await locator.WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible
            });
        }

        protected async Task ClickAsync(ILocator locator)
        {
            await WaitForVisibleAsync(locator);
            await locator.ClickAsync();
        }

        protected async Task FillAsync(ILocator locator, string value)
        {
            await WaitForVisibleAsync(locator);
            await locator.FillAsync(value);
        }

        protected async Task SelectOptionAsync(ILocator locator, string value)
        {
            await WaitForVisibleAsync(locator);
            await locator.SelectOptionAsync(value);
        }
    }
}
