namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Math"/> type.
/// </summary>
public static partial class MathExt
{
    /// <summary>
    /// Checks if value is within [minimum, maximum).
    /// </summary>
    /// <param name="minimum">Minimum limit, inclusive.</param>
    /// <param name="maximum">Maximum limit, exclusive.</param>
    public static bool IsWithin(this sbyte value, sbyte minimum, sbyte maximum)
    {
        return (value >= minimum && value < maximum);
    }

    /// <summary>
    /// Checks if value is within [minimum, maximum).
    /// </summary>
    /// <param name="minimum">Minimum limit, inclusive.</param>
    /// <param name="maximum">Maximum limit, exclusive.</param>
    public static bool IsWithin(this byte value, byte minimum, byte maximum)
    {
        return (value >= minimum && value < maximum);
    }

    /// <summary>
    /// Checks if value is within [minimum, maximum).
    /// </summary>
    /// <param name="minimum">Minimum limit, inclusive.</param>
    /// <param name="maximum">Maximum limit, exclusive.</param>
    public static bool IsWithin(this ushort value, ushort minimum, ushort maximum)
    {
        return (value >= minimum && value < maximum);
    }

    /// <summary>
    /// Checks if value is within [minimum, maximum).
    /// </summary>
    /// <param name="minimum">Minimum limit, inclusive.</param>
    /// <param name="maximum">Maximum limit, exclusive.</param>
    public static bool IsWithin(this short value, short minimum, short maximum)
    {
        return (value >= minimum && value < maximum);
    }

    /// <summary>
    /// Checks if value is within [minimum, maximum).
    /// </summary>
    /// <param name="minimum">Minimum limit, inclusive.</param>
    /// <param name="maximum">Maximum limit, exclusive.</param>
    public static bool IsWithin(this uint value, uint minimum, uint maximum)
    {
        return (value >= minimum && value < maximum);
    }

    /// <summary>
    /// Checks if value is within [minimum, maximum).
    /// </summary>
    /// <param name="minimum">Minimum limit, inclusive.</param>
    /// <param name="maximum">Maximum limit, exclusive.</param>
    public static bool IsWithin(this int value, int minimum, int maximum)
    {
        return (value >= minimum && value < maximum);
    }

    /// <summary>
    /// Checks if value is within [minimum, maximum).
    /// </summary>
    /// <param name="minimum">Minimum limit, inclusive.</param>
    /// <param name="maximum">Maximum limit, exclusive.</param>
    public static bool IsWithin(this ulong value, ulong minimum, ulong maximum)
    {
        return (value >= minimum && value < maximum);
    }

    /// <summary>
    /// Checks if value is within [minimum, maximum).
    /// </summary>
    /// <param name="minimum">Minimum limit, inclusive.</param>
    /// <param name="maximum">Maximum limit, exclusive.</param>
    public static bool IsWithin(this long value, long minimum, long maximum)
    {
        return (value >= minimum && value < maximum);
    }

    /// <summary>
    /// Checks if value is within [minimum, maximum).
    /// </summary>
    /// <param name="minimum">Minimum limit, inclusive.</param>
    /// <param name="maximum">Maximum limit, exclusive.</param>
    public static bool IsWithin(this float value, float minimum, float maximum)
    {
        return (value >= minimum && value < maximum);
    }

    /// <summary>
    /// Checks if value is within [minimum, maximum).
    /// </summary>
    /// <param name="minimum">Minimum limit, inclusive.</param>
    /// <param name="maximum">Maximum limit, exclusive.</param>
    public static bool IsWithin(this double value, double minimum, double maximum)
    {
        return (value >= minimum && value < maximum);
    }

    /// <summary>
    /// Checks if value is within [minimum, maximum).
    /// </summary>
    /// <param name="minimum">Minimum limit, inclusive.</param>
    /// <param name="maximum">Maximum limit, exclusive.</param>
    public static bool IsWithin(this decimal value, decimal minimum, decimal maximum)
    {
        return (value >= minimum && value < maximum);
    }

    /// <summary>
    /// Checks if value is within [minimum, maximum) using IComparable.CompareTo().
    /// </summary>
    /// <param name="minimum">Minimum limit, inclusive.</param>
    /// <param name="maximum">Maximum limit, exclusive.</param>
    public static bool IsWithin<T>(this T value, T minimum, T maximum) where T : IComparable
    {
        return value.CompareTo(minimum) >= 0 && value.CompareTo(maximum) < 0;
    }
}
