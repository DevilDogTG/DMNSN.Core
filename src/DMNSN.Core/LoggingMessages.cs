using Microsoft.Extensions.Logging;

namespace DMNSN.Core;

/// <summary>
/// Shared high-performance logging methods using source generators.
/// </summary>
public static partial class LoggingMessages
{
    /// <summary>
    /// Debugs the specified message.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="message">The message.</param>
    [LoggerMessage(Level = LogLevel.Trace, Message = "{Message}")]
    public static partial void Trace(this ILogger logger, string message);

    /// <summary>
    /// Debugs the specified message.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="message">The message.</param>
    [LoggerMessage(Level = LogLevel.Debug, Message = "{Message}")]
    public static partial void Debug(this ILogger logger, string message);

    /// <summary>
    /// Informations the specified message.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="message">The message.</param>
    [LoggerMessage(Level = LogLevel.Information, Message = "{Message}")]
    public static partial void Information(this ILogger logger, string message);

    /// <summary>
    /// Warns the specified message.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="message">The message.</param>
    [LoggerMessage(Level = LogLevel.Warning, Message = "{Message}")]
    public static partial void Warning(this ILogger logger, string message);

    /// <summary>
    /// Errors the specified message.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="message">The message.</param>
    [LoggerMessage(Level = LogLevel.Error, Message = "{Message}")]
    public static partial void Error(this ILogger logger, string message);

    /// <summary>
    /// Errors the specified ex.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="ex">The ex.</param>
    /// <param name="message">The message.</param>
    [LoggerMessage(Level = LogLevel.Error, Message = "{Message}")]
    public static partial void Error(this ILogger logger, Exception ex, string message);
}
