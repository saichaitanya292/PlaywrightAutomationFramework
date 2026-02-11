using Microsoft.Extensions.Configuration;

namespace PlaywrightAutomation.Utilities
{
    public static class ConfigReader
    {
        private static IConfigurationRoot _config;

        static ConfigReader()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("Config/appsettings.json")
                .Build();
        }

        public static string Browser => _config["Browser"]!;
        public static bool Headless => bool.Parse(_config["Headless"]!);
        public static string BaseUrl => _config["BaseUrl"]!;
    }
}
