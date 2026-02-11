using Microsoft.Playwright;
using PlaywrightAutomation.Utilities;

namespace PlaywrightAutomation.Drivers
{
    public class PlaywrightDriver
    {
        public IPlaywright Playwright { get; private set; } = null!;
        public IBrowser Browser { get; private set; } = null!;
        public IPage Page { get; private set; } = null!;

        public async Task InitializeAsync()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            Browser = ConfigReader.Browser switch
            {
                "Firefox" => await Playwright.Firefox.LaunchAsync(
                    new BrowserTypeLaunchOptions
                    {
                        Headless = ConfigReader.Headless
                    }),

                "Webkit" => await Playwright.Webkit.LaunchAsync(
                    new BrowserTypeLaunchOptions
                    {
                        Headless = ConfigReader.Headless
                    }),

                _ => await Playwright.Chromium.LaunchAsync(
                    new BrowserTypeLaunchOptions
                    {
                        Headless = ConfigReader.Headless
                    })
            };

            // 🔥 MAXIMIZED WINDOW
            var context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = null   // Maximizes window
            });

            Page = await context.NewPageAsync();
        }

        public async Task QuitAsync()
        {
            if (Browser != null)
            {
                await Browser.CloseAsync();
            }
        }
    }
}
