using System.Reflection;
using Console = Colorful.Console;

namespace EdsLibrary.ConsoleHelpers;

public class ConsoleMenu
{
    private readonly Dictionary<ConsoleKey, Tuple<string, Action>> options;
    private readonly Dictionary<ConsoleKey, Action> hiddenOptions;
    private ConsoleKeyInfo? lastInput;
    private bool repeat;

    public const ConsoleKey ExitKey = ConsoleKey.Escape;
    public const ConsoleKey RepeatKey = ConsoleKey.UpArrow;

    public ConsoleMenu()
    {
        lastInput = null;
        repeat = false;
        options = new Dictionary<ConsoleKey, Tuple<string, Action>>();
        hiddenOptions = new Dictionary<ConsoleKey, Action>
        {
            { ExitKey, Exit },
            { RepeatKey, Repeat }
        };
    }

    public ConsoleKeyInfo Input { get; private set; }
    public bool HasExited { get; private set; } = false;
    public IEnumerable<ConsoleKey> Keys => options.Keys.Union(hiddenOptions.Keys);

    public void DisplayContinously()
    {
        do
        {
            Display();
        }
        while (HasExited == false);
    }

    public void Display()
    {
        HasExited = false;
        lastInput = Input;
        if (repeat == false)
        {
            Console.WriteLine();
            PrintHeading();
            Console.Write("Press Key: ");
            do
            {
                Input = Console.ReadKey(true);
            }
            while (Keys.Contains(Input.Key) == false);
        }
        repeat = false;

        if (Input.Key == ExitKey)
        {
            Console.WriteLine(Input.Key.ToString(), Color.Aquamarine);
            Console.WriteLine();
            Exit();
            return;
        }
        else if (options.ContainsKey(Input.Key))
        {
            Console.WriteLine(Input.Key.ToString(), Color.Aquamarine);
            Console.WriteLine();
            options[Input.Key].Item2.Invoke();
        }
        else if (hiddenOptions.ContainsKey(Input.Key))
        {
            hiddenOptions[Input.Key].Invoke();
        }
    }

    public void AddItem(ConsoleKey key, string name, Action action)
    {
        if (Keys.Contains(Input.Key))
        {
            throw new ArgumentException($"Cannot add key '{ExitKey}', as it is already in use.");
        }

        Tuple<string, Action> tuple = new(name.ToLowerInvariant(), action);
        options.Add(key, tuple);
    }

    public void AddHiddenItem(ConsoleKey key, Action action)
    {
        if (Keys.Contains(Input.Key))
        {
            throw new ArgumentException($"Cannot add key '{ExitKey}', as it is already in use.");
        }

        hiddenOptions.Add(key, action);
    }

    public void Exit()
    {
        HasExited = true;
        lastInput = null;
        repeat = false;
    }

    public void Repeat()
    {
        if (lastInput == null) return;
        Input = (ConsoleKeyInfo)lastInput;
        repeat = true;
    }

    private void PrintHeading()
    {
        foreach (KeyValuePair<ConsoleKey, Tuple<string, Action>> item in options)
        {
            Console.Write("|");
            Console.Write(item.Key.ToString(), Color.White);
            Console.Write($":{item.Value.Item1}");
            Console.Write(" ");
        }
        Console.WriteLine();
    }

    public static void RunProgramAndExit(string name, Action runMethod)
    {
        try
        {
            RunProgram(name, runMethod);
            ExitProgram(0);
        }
        catch (Exception e)
        {
            LogException(e);
            ExitProgram(e.HResult);
        }
    }

    public static void RunProgram(string name, Action runMethod)
    {
        string version = Assembly.GetCallingAssembly().GetName().Version.ToString();
        Console.Title = name;
        Console.WriteLine($"{name} v{version}");
        runMethod.Invoke();
        Console.WriteLine($"\n{name} finished.");
    }

    public static void LogException(Exception e)
    {
        Console.WriteLine($"Error: {e.Message}", Color.Red);
        Console.WriteLine($"Stack Trace:", Color.Red);
        Console.WriteLine(e.StackTrace, Color.Red);
    }

    public static void ExitProgram(int exitCode)
    {
        var ExitKey = ConsoleKey.Escape;
        Console.WriteLine($"Press '{ExitKey}' to exit...");
        while (Console.KeyAvailable) Console.ReadKey(true);
        while (Console.ReadKey(true).Key != ExitKey) { }
        Environment.Exit(exitCode);
    }

    public static void List(params string[] strings)
    {
        Console.WriteLine("Available: ");
        for (int i = 0; i < strings.Length; i++)
        {
            Console.Write("[");
            Console.Write(i, Color.White);
            Console.Write("] ");
            Console.WriteLine(strings[i]);
        }

        if (strings.Length == 0)
        {
            Console.WriteLine($"None found.", Color.Orange);
        }
    }

    public static string Choose(params string[] strings)
    {
        List(strings);
        if (strings.Length == 0) return string.Empty;

        do
        {
            Console.Write("Enter Id: ");
            string input = Console.ReadLine();
            try
            {
                int id = int.Parse(input);
                string file = strings[id];
                return file;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: '{e.Message}'", Color.Red);
            }
        }
        while (true);
    }
}
