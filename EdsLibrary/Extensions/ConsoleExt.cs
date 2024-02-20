using System.Text.Json;

namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Console"/> type.
/// </summary>
public static partial class ConsoleExt
{
    public static void ClearRows(int start, int end)
    {
        string emptyLine = new(' ', Console.BufferWidth);
        for (int i = start; i <= end; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.WriteLine(emptyLine);
        }
    }

    public static T RequestInputValue<T>(string name)
    {
        T? value = default;
        do
        {
            Console.Write($"Please enter a value for '{name}': ");
            var input = Console.ReadLine();
            try
            {
                value = JsonSerializer.Deserialize<T>(input) ?? throw new JsonException("Value cannot be null");
            }
            catch (JsonException) { }
        }
        while (value == null);

        return value;
    }
}
