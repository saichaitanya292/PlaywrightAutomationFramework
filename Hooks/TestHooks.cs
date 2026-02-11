using Reqnroll;
using PlaywrightAutomation.Drivers;
using PlaywrightAutomation.Reporting;
using AventStack.ExtentReports;

namespace PlaywrightAutomation.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private PlaywrightDriver? _driver;

        public TestHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            _driver = new PlaywrightDriver();
            await _driver.InitializeAsync();

            _scenarioContext["Driver"] = _driver;
            _scenarioContext["Page"] = _driver.Page;

            ExtentManager.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        // 🔥 Screenshot after every step (SAFE)
        [AfterStep]
        public async Task AfterEachStep()
        {
            if (_driver?.Page == null)
                return;

            if (_scenarioContext.StepContext == null)
                return;

            var test = ExtentManager.GetTest();
            if (test == null)
                return;

            var screenshotDirectory = Path.Combine(
                Directory.GetCurrentDirectory(),
                "TestResults",
                "StepScreenshots");

            Directory.CreateDirectory(screenshotDirectory);

            var stepText = _scenarioContext.StepContext.StepInfo?.Text ?? "UnknownStep";

            stepText = stepText
                .Replace(" ", "_")
                .Replace("\"", "")
                .Replace("'", "");

            var fileName =
                $"{stepText}_{DateTime.Now:yyyyMMdd_HHmmss}.png";

            var fullPath = Path.Combine(screenshotDirectory, fileName);

            await _driver.Page.ScreenshotAsync(new()
            {
                Path = fullPath,
                FullPage = true
            });

            test.Info($"Step: {stepText}")
                .AddScreenCaptureFromPath(fullPath);
        }

        // 🔥 Final scenario screenshot
        [AfterScenario]
        public async Task AfterScenario()
        {
            if (_driver?.Page == null)
                return;

            var test = ExtentManager.GetTest();

            var screenshotDirectory = Path.Combine(
                Directory.GetCurrentDirectory(),
                "TestResults",
                "Screenshots");

            Directory.CreateDirectory(screenshotDirectory);

            var fileName =
                $"{_scenarioContext.ScenarioInfo.Title.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.png";

            var fullPath = Path.Combine(screenshotDirectory, fileName);

            await _driver.Page.ScreenshotAsync(new()
            {
                Path = fullPath,
                FullPage = true
            });

            if (_scenarioContext.TestError == null)
            {
                test?.Pass("Scenario Passed")
                    .AddScreenCaptureFromPath(fullPath);
            }
            else
            {
                test?.Fail(_scenarioContext.TestError)
                    .AddScreenCaptureFromPath(fullPath);
            }

            await _driver.QuitAsync();
            ExtentManager.Flush();
        }
    }
}
