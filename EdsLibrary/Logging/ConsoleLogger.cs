namespace EdsLibrary.Logging;

public class ConsoleLogger : ILogger
{
    private string lastLog = null;

#if DEBUG
    public LogPriority LogPriority { get; set; } = LogPriority.Debug;
#else
    public LogPriority LogPriority { get; set; } = LogPriority.Low;
#endif
    public bool SpamProtection { get; set; } = false;

    public void LogTableHeaders(TableFormatter table, LogPriority priority)
    {
        Log(table.GetHeadersString(), priority, ConsoleColor.White);
    }

    public void LogTableHeaders(TableFormatter table, LogPriority priority, ConsoleColor color)
    {
        Log(table.GetHeadersString(), priority, color);
    }

    public void LogTableValues(TableFormatter table, LogPriority priority)
    {
        Log(table.GetValuesString(), priority);
    }

    public void LogTableValues(TableFormatter table, LogPriority priority, ConsoleColor color)
    {
        Log(table.GetValuesString(), priority, color);
    }

    public void Log(string value, LogPriority priority)
    {
        if (SpamProtection && lastLog == value) return;
        if (priority < LogPriority) return;

        Console.WriteLine(value);
        lastLog = value;
    }

    public void Log(string value, LogPriority priority, ConsoleColor color)
    {
        if (SpamProtection && lastLog == value) return;
        if (priority < LogPriority) return;

        ConsoleColor oldColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(value, color);
        Console.ForegroundColor = oldColor;
        lastLog = value;
    }

    public void LogError(string value) => Log(value, LogPriority.High, ConsoleColor.Red);

    public void LogNoNewline(string value, LogPriority priority)
    {
        if (SpamProtection && lastLog == value) return;
        if (priority < LogPriority) return;

        Console.Write(value);
        lastLog = value;
    }

    public void LogNoNewline(string value, LogPriority priority, ConsoleColor color)
    {
        if (SpamProtection && lastLog == value) return;
        if (priority < LogPriority) return;

        ConsoleColor oldColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(value, color);
        Console.ForegroundColor = oldColor;
        lastLog = value;
    }
}
