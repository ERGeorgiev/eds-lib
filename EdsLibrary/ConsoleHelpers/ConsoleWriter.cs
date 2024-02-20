using EdsLibrary.Enums;

namespace EdsLibrary.ConsoleHelpers;

public class ConsoleWriter
{
#if DEBUG
    public static Priority MinimumPriority { get; set; } = Priority.Low;
#else
    public static Priority MinimumPriority { get; set; } = Priority.Low;
#endif

    public static void Write(string value, Priority priority)
    {
        if (priority < MinimumPriority) return;

        Console.WriteLine(value);
    }

    public static void Write(string value, Priority priority, ConsoleColor color)
    {
        if (priority < MinimumPriority) return;

        ConsoleColor oldColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(value, color);
        Console.ForegroundColor = oldColor;
    }

    public static void WriteError(string value) => Write(value, Priority.High, ConsoleColor.Red);
}
