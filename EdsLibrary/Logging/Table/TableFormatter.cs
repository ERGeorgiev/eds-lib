namespace EdsLibrary.Logging.Table;

public class TableFormatter
{
    private List<LogItem> LogItems { get; set; } = new List<LogItem>();

    public static TableFormatter operator +(TableFormatter a, TableFormatter b)
    {
        a.Add(b);
        return a;
    }

    /// <summary>
    /// Adds all items from the given source.
    /// </summary>
    /// <param name="source">Source to use.</param>
    public void Add(TableFormatter source)
    {
        LogItems.AddRange(source.LogItems);
    }

    /// <summary>
    /// Adds a custom string value to the formatter.
    /// </summary>
    /// <param name="name">Name of the value.</param>
    /// <param name="value">Value.</param>
    /// <param name="length">Max text length.</param>
    public void Add(string name, string value, int length)
    {
        LogItem item = new(name, value, length);
        LogItems.Add(item);
    }

    /// <summary>
    /// Adds an item to the formatter.
    /// </summary>
    /// <param name="name">Name of the item.</param>
    /// <param name="value">Value of the item.</param>
    /// <param name="format">Item string formatting.</param>
    /// <param name="length">Max text length.</param>
    public void Add(string name, float value, string format, int length)
    {
        LogItem item = new(name, value, format, length);
        LogItems.Add(item);
    }

    /// <summary>
    /// Adds a custom string value to the formatter for comparison.
    /// </summary>
    /// <param name="name">Name of the values.</param>
    /// <param name="values">Values.</param>
    /// <param name="length">Max text length.</param>
    public void Add(string name, KeyValuePair<string, string> values, int length)
    {
        LogItem itemA = new(name, values.Key, length);
        LogItem itemB = new(name, values.Value, length);
        LogItems.Add(itemA);
        LogItems.Add(itemB);
    }

    /// <summary>
    /// Adds two items to the formatter for comparison.
    /// </summary>
    /// <param name="name">Name of the items.</param>
    /// <param name="values">Items values.</param>
    /// <param name="format">Items string formatting.</param>
    /// <param name="length">Max text length.</param>
    public void Add(string name, KeyValuePair<float, float> values, string format, int length)
    {
        LogItem itemA = new(name, values.Key, format, length);
        LogItem itemB = new(name, values.Value, format, length);
        LogItems.Add(itemA);
        LogItems.Add(itemB);
    }

    /// <summary>
    /// Adds a custom string value to the formatter for comparison.
    /// </summary>
    /// <param name="name">Name of the values.</param>
    /// <param name="values">Values.</param>
    /// <param name="length">Max text length.</param>
    public void Add(string name, string valueA, string valueB, int length)
    {
        LogItem itemA = new(name, valueA, length);
        LogItem itemB = new(name, valueB, length);
        LogItems.Add(itemA);
        LogItems.Add(itemB);
    }

    /// <summary>
    /// Adds two items to the formatter for comparison.
    /// </summary>
    /// <param name="name">Name of the items.</param>
    /// <param name="values">Items values.</param>
    /// <param name="format">Items string formatting.</param>
    /// <param name="length">Max text length.</param>
    public void Add(string name, float valueA, float valueB, string format, int length)
    {
        LogItem itemA = new(name, valueA, format, length);
        LogItem itemB = new(name, valueB, format, length);
        LogItems.Add(itemA);
        LogItems.Add(itemB);
    }

    public IEnumerable<string> GetHeaders()
    {
        return LogItems.Select(x => x.name);
    }

    public IEnumerable<string> GetValues()
    {
        return LogItems.Select(x => x.Value);
    }

    public string GetHeadersString()
    {
        string output = string.Empty;
        foreach (var nameGroup in LogItems.GroupBy(x => x.name))
        {
            output += GetFormattedHeader(nameGroup);
        }

        return output;
    }

    public string GetValuesString()
    {
        string output = string.Empty;
        foreach (var nameGroup in LogItems.GroupBy(x => x.name))
        {
            output += GetFormattedValues(nameGroup);
        }

        return output;
    }

    public override string ToString()
    {
        string output = string.Empty;
        List<IEnumerable<string>> lines = new()
        {
            GetHeaders(),
            GetValues()
        };

        foreach (var line in lines)
        {
            var values = string.Join(",", line);
            output += values;
        }

        return output;
    }

    private static string GetFormattedHeader(IEnumerable<LogItem> logItems)
    {
        string output = string.Empty;
        output += string.Format("|{0} ", logItems.ElementAt(0).Header);
        for (int i = 1; i < logItems.Count(); i++)
        {
            output += string.Format($"{{0,-{logItems.ElementAt(i).Header.Length + 3}}}");
        }

        return output;
    }

    private static string GetFormattedValues(IEnumerable<LogItem> logItems)
    {
        string output = string.Empty;
        output += string.Format("|{0} ", logItems.ElementAt(0).Value);
        for (int i = 1; i < logItems.Count(); i++)
        {
            output += string.Format("[{0}] ", logItems.ElementAt(i).Value);
        }

        return output;
    }

    private class LogItem
    {
        private readonly static int ScientificLength = (-1f).ToString("E0").Length;
        public readonly string name;
        private readonly string valueString;
        private readonly int length;

        public LogItem(string name, float value, string format, int length)
        {
            this.name = name;
            this.length = length;
            Validate();
            valueString = ToValueString(value, format);
        }

        public LogItem(string name, string value, int length)
        {
            this.name = name;
            this.length = length;
            Validate();
            valueString = value;
        }

        private void Validate()
        {
            if (length <= 0) throw new Exception($"Length '{length}' must be bigger than 0.");
            if (name.Length > length) throw new Exception($"Name length '{name.Length}' cannot be longer than length '{length}'.");
        }

        private string ToValueString(float value, string format)
        {
            string formattedValue = value.ToString(format);
            if (formattedValue.Length > length)
            {
                int scientificPrecision = ScientificLength - length;
                if (scientificPrecision >= 0)
                {
                    formattedValue = value.ToString($"E{scientificPrecision}");
                    if (value >= 0)
                    {
                        formattedValue = "+" + formattedValue;
                    }
                }
                else
                {
                    formattedValue = new string('#', length);
                }
            }
            else
            {
                formattedValue = value.ToString(format);
            }

            return formattedValue;
        }

        public string Value
        {
            get => string.Format($"{{0,-{length}}}", valueString);
        }

        public string Header
        {
            get => string.Format($"{{0,-{length}}}", name);
        }
    }
}
