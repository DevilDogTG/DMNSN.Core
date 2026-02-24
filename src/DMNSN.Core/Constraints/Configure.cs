namespace DMNSN.Core.Constraints;

/// <summary>
/// Provides configuration key constants used for accessing application settings.
/// </summary>
/// <remarks>This class contains predefined keys for commonly used configuration sections,  such as application
/// settings and logging settings. These keys can be used  to retrieve configuration values from a configuration
/// provider.</remarks>
public static partial class ConfigureKey
{
    /// <summary>
    /// The configuration section key for application settings ("AppSettings").
    /// </summary>
    public const string Application = "AppSettings";

    /// <summary>
    /// The configuration section key for logging settings ("LoggingSettings").
    /// </summary>
    public const string Logging = "LoggingSettings";
}

/// <summary>
/// Provides constants for commonly used configuration file names in the application.
/// </summary>
/// <remarks>These constants represent the default file names for application and logging configuration files.
/// They can be used to standardize file references across the application.</remarks>
public static partial class ConfigureFile
{
    /// <summary>
    /// The default file name for application settings ("appsettings.json").
    /// </summary>
    public const string Application = "appsettings.json";

    /// <summary>
    /// The default file name for logging settings ("logsettings.json").
    /// </summary>
    public const string Logging = "logsettings.json";
}
