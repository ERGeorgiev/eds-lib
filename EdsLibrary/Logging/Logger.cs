using EdsLibrary.Logging.JsonConverters;
using System.Diagnostics;
using System.Text.Json;

namespace EdsLibrary.Logging;

/// <summary>
/// Writes to the console.
/// </summary>
public class Logger
{
    public static readonly JsonSerializerOptions SerializerOptions = GetSerializerOptions();

    public static bool WriteToConsole { get; set; } = true;
    public static List<Action<string>> Outputs { get; } = new();

#if DEBUG
    public static LogLevel Level { get; set; } = LogLevel.Debug;
#elif RELEASE
    public static LogLevel Level { get; set; } = LogLevel.None;
#endif

    public static void LogTrace(Func<string> getMessage, Exception? exception = null)
        => Log(LogLevel.Trace, getMessage, exception);

    public static void LogTrace(string message, Exception? exception = null)
        => Log(LogLevel.Trace, message, exception);

    public static void LogTrace(Exception exception)
        => Log(LogLevel.Trace, exception);

    public static void LogDebug(Func<string> getMessage, Exception? exception = null)
        => Log(LogLevel.Debug, getMessage, exception);

    public static void LogDebug(string message, Exception? exception = null)
        => Log(LogLevel.Debug, message, exception);

    public static void LogDebug(Exception exception)
        => Log(LogLevel.Debug, exception);

    public static void LogInformation(Func<string> getMessage, Exception? exception = null)
        => Log(LogLevel.Information, getMessage, exception);

    public static void LogInformation(string message, Exception? exception = null)
        => Log(LogLevel.Information, message, exception);

    public static void LogInformation(Exception exception)
        => Log(LogLevel.Information, exception);

    public static void LogWarning(Func<string> getMessage, Exception? exception = null)
        => Log(LogLevel.Warning, getMessage, exception);

    public static void LogWarning(string message, Exception? exception = null)
        => Log(LogLevel.Warning, message, exception);

    public static void LogWarning(Exception exception)
        => Log(LogLevel.Warning, exception);

    public static void LogError(Func<string> getMessage, Exception? exception = null)
        => Log(LogLevel.Error, getMessage, exception);

    public static void LogError(string message, Exception? exception = null)
        => Log(LogLevel.Error, message, exception);

    public static void LogError(Exception exception)
        => Log(LogLevel.Error, exception);

    public static void LogCritical(Func<string> getMessage, Exception? exception = null)
        => Log(LogLevel.Critical, getMessage, exception);

    public static void LogCritical(string message, Exception? exception = null)
        => Log(LogLevel.Critical, message, exception);

    public static void LogCritical(Exception exception)
        => Log(LogLevel.Critical, exception);

    public static void Log(LogLevel logLevel, Func<string>? getMessage = null, Exception? exception = null)
    {
        if (Level > logLevel) return; // To avoid invoking getMessage
        LogInternal(logLevel, getMessage?.Invoke(), exception);
    }

    public static void Log(LogLevel logLevel, string? message = null, Exception? exception = null)
        => LogInternal(logLevel, message, exception);

    public static void Log(LogLevel logLevel, Exception exception)
        => LogInternal(logLevel, null, exception);

    private static void LogInternal(LogLevel logLevel, string? message = null, Exception? exception = null)
    {
        if (Level > logLevel) return;

        var currColor = Console.ForegroundColor;
        Console.ForegroundColor = GetLogLevelConsoleColor(logLevel);

        var methodInfo = new StackTrace().GetFrame(3).GetMethod();
        var className = methodInfo.ReflectedType.Name;
        var msg = $"{DateTime.Now:[HH:mm:ss]} {className}: ";
        if (message != null)
        {
            msg += message;
        }
        if (exception != null)
        {
            if (message != null) msg += "; ";
            msg += $"Exception:\r\n'{JsonSerializer.Serialize(exception, SerializerOptions)}'";
        }
        if (WriteToConsole) Console.WriteLine(msg);
        Outputs.ForEach(o => o.Invoke(msg));

        Console.ForegroundColor = currColor;
    }

    private static ConsoleColor GetLogLevelConsoleColor(LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.Trace => ConsoleColor.DarkGray,
            LogLevel.Debug => ConsoleColor.Gray,
            LogLevel.Information => ConsoleColor.White,
            LogLevel.Warning => ConsoleColor.Yellow,
            LogLevel.Error => ConsoleColor.Red,
            LogLevel.Critical => ConsoleColor.DarkRed,
            _ => ConsoleColor.White,
        };
    }

    private static JsonSerializerOptions GetSerializerOptions()
    {
        var serializer = new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true };
        serializer.Converters.Add(new ExceptionConverter());

        return serializer;
    }
}
