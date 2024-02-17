namespace EdsLibrary.Extensions;

public static partial class ConsoleExt
{
    public static void ClearRows(int start, int end)
    {
        string emptyLine = new string(' ', Console.BufferWidth);
        for (int i = start; i <= end; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.WriteLine(emptyLine);
        }
    }

    public static double ScanDouble(string name)
    {
        double input;
        do
        {
            Console.Write($"Please enter a value for '{name}': ");
        }
        while (!double.TryParse(Console.ReadLine(), out input));

        return input;
    }

    public static int ScanInt(string name)
    {
        int input;
        do
        {
            Console.Write($"Please enter a value for '{name}': ");
        }
        while (!int.TryParse(Console.ReadLine(), out input));

        return input;
    }
}
