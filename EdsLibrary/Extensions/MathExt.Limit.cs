namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Math"/> type.
/// </summary>
public static partial class MathExt
{
    /// <summary>
    /// Constricts the value within [minimum, maximum].
    /// </summary>
    public static sbyte Limit(this sbyte value, sbyte minimum, sbyte maximum)
    {
        return Math.Min(Math.Max(value, minimum), maximum);
    }

    /// <summary>
    /// Constricts the value within [minimum, maximum].
    /// </summary>
    public static byte Limit(this byte value, byte minimum, byte maximum)
    {
        return Math.Min(Math.Max(value, minimum), maximum);
    }

    /// <summary>
    /// Constricts the value within [minimum, maximum].
    /// </summary>
    public static ushort Limit(this ushort value, ushort minimum, ushort maximum)
    {
        return Math.Min(Math.Max(value, minimum), maximum);
    }

    /// <summary>
    /// Constricts the value within [minimum, maximum].
    /// </summary>
    public static short Limit(this short value, short minimum, short maximum)
    {
        return Math.Min(Math.Max(value, minimum), maximum);
    }

    /// <summary>
    /// Constricts the value within [minimum, maximum].
    /// </summary>
    public static uint Limit(this uint value, uint minimum, uint maximum)
    {
        return Math.Min(Math.Max(value, minimum), maximum);
    }

    /// <summary>
    /// Constricts the value within [minimum, maximum].
    /// </summary>
    public static int Limit(this int value, int minimum, int maximum)
    {
        return Math.Min(Math.Max(value, minimum), maximum);
    }

    /// <summary>
    /// Constricts the value within [minimum, maximum].
    /// </summary>
    public static ulong Limit(this ulong value, ulong minimum, ulong maximum)
    {
        return Math.Min(Math.Max(value, minimum), maximum);
    }

    /// <summary>
    /// Constricts the value within [minimum, maximum].
    /// </summary>
    public static long Limit(this long value, long minimum, long maximum)
    {
        return Math.Min(Math.Max(value, minimum), maximum);
    }

    /// <summary>
    /// Constricts the value within [minimum, maximum].
    /// </summary>
    public static float Limit(this float value, float minimum, float maximum)
    {
        return Math.Min(Math.Max(value, minimum), maximum);
    }
    /// <summary>
    /// Constricts the value within [minimum, maximum].
    /// </summary>

    public static double Limit(this double value, double minimum, double maximum)
    {
        return Math.Min(Math.Max(value, minimum), maximum);
    }

    /// <summary>
    /// Constricts the value within [minimum, maximum].
    /// </summary>
    public static decimal Limit(this decimal value, decimal minimum, decimal maximum)
    {
        return Math.Min(Math.Max(value, minimum), maximum);
    }
}
