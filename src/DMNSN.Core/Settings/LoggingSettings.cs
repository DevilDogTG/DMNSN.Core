namespace DMNSN.Core.Settings;

/// <summary>
/// Represents the configuration settings for logging, including file size limits, flush intervals,  and specific
/// settings for console and file logging.
/// </summary>
/// <remarks>This class provides a centralized way to configure logging behavior for an application.  It includes
/// options for controlling the maximum file size for log files, the interval at which  logs are flushed, and the
/// settings for both console and file-based logging.</remarks>
public partial class LoggingSettings
{
    /// <summary>
    /// Gets or sets the size of the file in bytes.
    /// </summary>
    public long FileSize { get; set; } = 104857600;
    /// <summary>
    /// Gets or sets the interval, in seconds, at which data is flushed to the underlying storage.
    /// </summary>
    /// <remarks>Setting this property to a lower value increases the frequency of flush operations, which may
    /// improve data consistency but could impact performance. Conversely, higher values reduce the frequency of flush
    /// operations, potentially improving performance at the cost of delayed data persistence.</remarks>
    public int FlushInterval { get; set; } = 1;
    /// <summary>
    /// Gets or sets the logging settings for console output.
    /// </summary>
    public LoggingSetting ConsoleLog { get; set; } = new LoggingSetting() { Enable = false, MinimumLevel = "Information" };
    /// <summary>
    /// Gets or sets the logging settings for file-based logging.
    /// </summary>
    public LoggingSetting FileLog { get; set; } = new LoggingSetting();
}

/// <summary>
/// Represents the configuration settings for logging behavior in an application.
/// </summary>
/// <remarks>This class provides options to enable or disable logging, set the minimum log level,  specify the log
/// file path, and define the log message template. These settings  can be used to customize the logging output to suit
/// application requirements.</remarks>
public class LoggingSetting
{
    /// <summary>
    /// Gets or sets a value indicating whether the feature is enabled.
    /// </summary>
    public bool Enable { get; set; } = true;
    /// <summary>
    /// Gets or sets the minimum logging level for the application.
    /// </summary>
    public string MinimumLevel { get; set; } = "Debug";
    /// <summary>
    /// Gets or sets the file path where log entries are stored.
    /// </summary>
    public string Path { get; set; } = "logs/logging..log";
    /// <summary>
    /// Gets or sets the template used to format log messages.
    /// </summary>
    /// <remarks>The template defines the structure of log messages, including placeholders for  timestamp,
    /// log level, message content, and exceptions. Customize this property  to change the format of log
    /// output.</remarks>
    public string Template { get; set; } = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";
}
