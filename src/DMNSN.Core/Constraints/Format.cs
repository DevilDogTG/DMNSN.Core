using System.ComponentModel;

namespace DMNSN.Core.Constraints;

/// <summary>
/// Specifies the format options for representing dates as strings.
/// </summary>
/// <remarks>This enumeration provides predefined date format patterns that can be used to format or parse date
/// strings. Each value corresponds to a specific date format pattern, as described in its <see
/// cref="DescriptionAttribute"/>.</remarks>
public enum FormatDate
{
    /// <summary>Format: "ddMMyyyy"</summary>
    [Description("ddMMyyyy")]
    _ddMMyyyy,
    /// <summary>Format: "yyyyMMdd"</summary>
    [Description("yyyyMMdd")]
    _yyyyMMdd,
    /// <summary>Format: "dd/MM/yyyy"</summary>
    [Description("dd/MM/yyyy")]
    ddMMyyyy,
    /// <summary>Format: "yyyy-MM-dd"</summary>
    [Description("yyyy-MM-dd")]
    yyyyMMdd
}

/// <summary>
/// Specifies the available time formats for representing time values as strings.
/// </summary>
/// <remarks>This enumeration provides a set of predefined time formats that can be used to format time values.
/// Each format corresponds to a specific string representation of time, such as "HH:mm:ss" or "hh:mm tt".</remarks>
public enum FormatTime
{
    /// <summary>Format: "HHmmss"</summary>
    [Description("HHmmss")]
    _HHmmss,
    /// <summary>Format: "HHmmssfff"</summary>
    [Description("HHmmssfff")]
    _HHmmssfff,
    /// <summary>Format: "HH:mm:ss"</summary>
    [Description("HH:mm:ss")]
    HHmmss,
    /// <summary>Format: "HH:mm"</summary>
    [Description("HH:mm")]
    HHmm,
    /// <summary>Format: "hh:mm tt"</summary>
    [Description("hh:mm tt")]
    hhmmtt,
    /// <summary>Format: "HH:mm:ss.fff"</summary>
    [Description("HH:mm:ss.fff")]
    HHmmssfff
}

/// <summary>
/// Specifies predefined date and time format patterns for formatting and parsing operations.
/// </summary>
/// <remarks>This enumeration provides a set of commonly used date and time format strings. Each member
/// corresponds to a specific  format pattern that can be used for consistent date and time representation in
/// applications. The format patterns  follow standard .NET date and time formatting conventions.</remarks>
public enum FormatDateTime
{
    /// <summary>Format: "yyyyMMddHHmmssfff"</summary>
    [Description("yyyyMMddHHmmssfff")]
    _yyyyMMddHHmmssfff,
    /// <summary>Format: "yyyyMMddHHmmss"</summary>
    [Description("yyyyMMddHHmmss")]
    _yyyyMMddHHmmss,
    /// <summary>Format: "ddMMyyyyHHmmss"</summary>
    [Description("ddMMyyyyHHmmss")]
    _ddMMyyyyHHmmss,
    /// <summary>Format: "dd/MM/yyyy HH:mm:ss"</summary>
    [Description("dd/MM/yyyy HH:mm:ss")]
    ddMMyyyyHHmmss,
    /// <summary>Format: "yyyy-MM-dd HH:mm:ss"</summary>
    [Description("yyyy-MM-dd HH:mm:ss")]
    yyyyMMddHHmmss,
    /// <summary>Format: "dd/MM/yyyy HH:mm"</summary>
    [Description("dd/MM/yyyy HH:mm")]
    ddMMyyyyHHmm,
    /// <summary>Format: "yyyy-MM-dd HH:mm"</summary>
    [Description("yyyy-MM-dd HH:mm")]
    yyyyMMddHHmm,
    /// <summary>Format: "dd/MM/yyyy hh:mm tt"</summary>
    [Description("dd/MM/yyyy hh:mm tt")]
    ddMMyyyyhhmmtt,
    /// <summary>Format: "yyyy-MM-dd hh:mm tt"</summary>
    [Description("yyyy-MM-dd hh:mm tt")]
    yyyyMMddhhmmtt
}