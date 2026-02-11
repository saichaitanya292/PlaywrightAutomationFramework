using Serilog;
using System.IO;

namespace PlaywrightAutomation.Logging
{
    public static class LoggerConfig
    {
        public static void ConfigureLogger()
        {
            var logDirectory = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Logs");

            Directory.CreateDirectory(logDirectory);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(
                    Path.Combine(logDirectory, "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7)
                .CreateLogger();
        }
    }
}
