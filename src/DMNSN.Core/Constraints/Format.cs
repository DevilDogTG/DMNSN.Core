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
    [Description("ddMMyyyy")]
    _ddMMyyyy,
    [Description("yyyyMMdd")]
    _yyyyMMdd,
    [Description("dd/MM/yyyy")]
    ddMMyyyy,
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
    [Description("HHmmss")]
    _HHmmss,
    [Description("HHmmssfff")]
    _HHmmssfff,
    [Description("HH:mm:ss")]
    HHmmss,
    [Description("HH:mm")]
    HHmm,
    [Description("hh:mm tt")]
    hhmmtt,
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
    [Description("yyyyMMddHHmmssfff")]
    _yyyyMMddHHmmssfff,
    [Description("yyyyMMddHHmmss")]
    _yyyyMMddHHmmss,
    [Description("ddMMyyyyHHmmss")]
    _ddMMyyyyHHmmss,
    [Description("dd/MM/yyyy HH:mm:ss")]
    ddMMyyyyHHmmss,
    [Description("yyyy-MM-dd HH:mm:ss")]
    yyyyMMddHHmmss,
    [Description("dd/MM/yyyy HH:mm")]
    ddMMyyyyHHmm,
    [Description("yyyy-MM-dd HH:mm")]
    yyyyMMddHHmm,
    [Description("dd/MM/yyyy hh:mm tt")]
    ddMMyyyyhhmmtt,
    [Description("yyyy-MM-dd hh:mm tt")]
    yyyyMMddhhmmtt
}