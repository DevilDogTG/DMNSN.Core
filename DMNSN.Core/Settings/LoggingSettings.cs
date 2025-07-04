namespace DMNSN.Core.Settings;

public partial class LoggingSettings
{
    public long FileSize { get; set; } = 104857600;
    public int FlushInterval { get; set; } = 1;
    public LoggingSetting ConsoleLog { get; set; } = new LoggingSetting() { Enable = false, MinimumLevel = "Information" };
    public LoggingSetting FileLog { get; set; } = new LoggingSetting();
}

public class LoggingSetting
{
    public bool Enable { get; set; } = true;
    public string MinimumLevel { get; set; } = "Debug";
    public string Path { get; set; } = "logs/logging..log";
    public string Template { get; set; } = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";
}
