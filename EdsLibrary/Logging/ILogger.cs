using System;

namespace EdsLibrary.Logging
{
    public interface ILogger
    {
        bool SpamProtection { get; set; }

        LogPriority LogPriority { get; set; }

        void LogTableHeaders(TableFormatter table, LogPriority priority);

        void LogTableHeaders(TableFormatter table, LogPriority priority, ConsoleColor color);

        void LogTableValues(TableFormatter table, LogPriority priority);

        void LogTableValues(TableFormatter table, LogPriority priority, ConsoleColor color);

        void Log(string value, LogPriority priority);

        void Log(string value, LogPriority priority, ConsoleColor color);

        void LogError(string value);
    }
}