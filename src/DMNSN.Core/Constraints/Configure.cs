namespace DMNSN.Core.Constraints;

/// <summary>
/// Provides configuration key constants used for accessing application settings.
/// </summary>
/// <remarks>This class contains predefined keys for commonly used configuration sections,  such as application
/// settings and logging settings. These keys can be used  to retrieve configuration values from a configuration
/// provider.</remarks>
public static partial class ConfigureKey
{
    public const string Application = "AppSettings";
    public const string Logging = "LoggingSettings";
}

/// <summary>
/// Provides constants for commonly used configuration file names in the application.
/// </summary>
/// <remarks>These constants represent the default file names for application and logging configuration files.
/// They can be used to standardize file references across the application.</remarks>
public static partial class ConfigureFile
{
    public const string Application = "appsettings.json";
    public const string Logging = "logsettings.json";
}
