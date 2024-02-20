namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Random"/> type.
/// </summary>
public static partial class RandomExt
{
    public static Random Shared = new();

    /// <summary>
    /// Generates a sign (e.g. -1 or 1).
    /// </summary>
    public static int Sign(this Random random)
    {
        return (random.NextDouble() >= 0.5f) ? 1 : -1;
    }

    /// <summary>
    /// Generates a sign (e.g. -1 or 1).
    /// </summary>
    public static int Sign()
    {
        return (Shared.NextDouble() >= 0.5f) ? 1 : -1;
    }

    /// <summary>
    /// Returns a random element.
    /// </summary>wW
    public static T RandomElement<T>(this T[] elements)
    {
        return elements[Next(elements.Length)];
    }

    /// <summary>
    /// Returns a random element.
    /// </summary>
    public static T RandomElement<T>(this IList<T> elements)
    {
        return elements[Next(elements.Count)];
    }
}
