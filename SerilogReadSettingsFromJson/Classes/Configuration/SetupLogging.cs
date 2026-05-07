using Microsoft.Extensions.Configuration;
using Serilog;
using static System.DateTime;

namespace SerilogReadSettingsFromJson.Classes.Configuration;
internal class SetupLogging
{
    /// <summary>
    /// Configures Serilog logging for development environments with an alternate setup.
    /// </summary>
    /// <remarks>
    /// This method initializes a Serilog logger that writes log entries to a file. 
    /// The log file is stored in a directory named after the current date (in the format "YYYY-MM-DD") 
    /// within the "LogFiles" folder in the application's base directory.
    /// </remarks>
    public static void DevelopmentAlternate()
    {

        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month:D2}-{Now.Day:D2}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();
    }
    
    /// <summary>
    /// Configures Serilog logging for development environments using settings from a JSON configuration file.
    /// </summary>
    /// <remarks>
    /// This method reads logging configuration from the `appsettings.json` file located in the application's base directory.
    /// It creates and initializes a Serilog logger based on the settings defined in the JSON file.
    /// </remarks>
    public static void Development()
    {
        
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration) // requires Serilog.Settings.Configuration package
            .CreateLogger();
    }
}
