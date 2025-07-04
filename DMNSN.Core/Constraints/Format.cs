using System.ComponentModel;

namespace DMNSN.Core.Constraints;

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