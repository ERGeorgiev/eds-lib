namespace EdsLibrary.Logging;

public class CsvTableLogger : ILogger
{
    private string? lastLog = null;
    private readonly List<IEnumerable<string>> lines = new List<IEnumerable<string>>();

#if DEBUG
    public LogPriority LogPriority { get; set; } = LogPriority.Debug;
#else
    public LogPriority LogPriority { get; set; } = LogPriority.Low;
#endif

    public bool SpamProtection { get; set; } = false;

    public void LogTableHeaders(TableFormatter table, LogPriority priority)
    {
        if (priority < LogPriority) return;
        lines.Add(table.GetHeaders());
    }

    public void LogTableHeaders(TableFormatter table, LogPriority priority, ConsoleColor color) => LogTableHeaders(table, priority);

    public void LogTableValues(TableFormatter table, LogPriority priority)
    {
        if (priority < LogPriority) return;
        lines.Add(table.GetValues());
    }

    public void LogTableValues(TableFormatter table, LogPriority priority, ConsoleColor color) => LogTableValues(table, priority);

    public void Log(string value, LogPriority priority)
    {
        if (SpamProtection && lastLog == value) return;
        if (priority < LogPriority) return;

        lastLog = value;
    }

    public void Log(string value, LogPriority priority, ConsoleColor color)
    {
        if (SpamProtection && lastLog == value) return;
        if (priority < LogPriority) return;

        lastLog = value;
    }

    public void LogError(string value) => Log(value, LogPriority.High, ConsoleColor.Red);

    public void Flush(string path)
    {
        using (var w = new StreamWriter(path))
        {
            foreach (var line in lines)
            {
                var values = string.Join(",", line);
                if (SpamProtection && lastLog == values) continue;

                w.WriteLine(values);
                lastLog = values;
            }
            w.Flush();
        }
        lines.Clear();
    }
}
