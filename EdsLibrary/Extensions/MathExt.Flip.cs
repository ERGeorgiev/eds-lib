namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Math"/> type.
/// </summary>
public static partial class MathExt
{
    /// <summary>
    /// Flips a value from 0 to 1.
    /// Example: 0 would return 1.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    public static sbyte Flip(this sbyte value)
    {
        return (sbyte)(1 - value);
    }

    /// <summary>
    /// Flips a value from 0 to 1.
    /// Example: 0 would return 1.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    public static byte Flip(this byte value)
    {
        return (byte)(1 - value);
    }

    /// <summary>
    /// Flips a value from 0 to 1.
    /// Example: 0 would return 1.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    public static ushort Flip(this ushort value)
    {
        return (ushort)(1 - value);
    }

    /// <summary>
    /// Flips a value from 0 to 1.
    /// Example: 0 would return 1.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    public static short Flip(this short value)
    {
        return (short)(1 - value);
    }

    /// <summary>
    /// Flips a value from 0 to 1.
    /// Example: 0 would return 1.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    public static uint Flip(this uint value)
    {
        return 1 - value;
    }

    /// <summary>
    /// Flips a value from 0 to 1.
    /// Example: 0 would return 1.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    public static int Flip(this int value)
    {
        return 1 - value;
    }

    /// <summary>
    /// Flips a value from 0 to 1.
    /// Example: 0 would return 1.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    public static ulong Flip(this ulong value)
    {
        return 1 - value;
    }

    /// <summary>
    /// Flips a value from 0 to 1.
    /// Example: 0 would return 1.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    public static long Flip(this long value)
    {
        return 1 - value;
    }

    /// <summary>
    /// Flips a value from 0 to 1.
    /// Example: 0.25 would return 0.75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    public static float Flip(this float value)
    {
        return 1 - value;
    }

    /// <summary>
    /// Flips a value from 0 to 1.
    /// Example: 0.25 would return 0.75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    public static double Flip(this double value)
    {
        return 1 - value;
    }

    /// <summary>
    /// Flips a value from 0 to 1.
    /// Example: 0.25 would return 0.75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    public static decimal Flip(this decimal value)
    {
        return 1 - value;
    }

    /// <summary>
    /// Flips a value within limits.
    /// Example: 25 with limits 0 to 100 would return 75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Inclusive upper limit.</param>
    public static sbyte Flip(this sbyte value, sbyte min, sbyte max)
    {
        return (sbyte)((max + min) - value);
    }

    /// <summary>
    /// Flips a value within limits.
    /// Example: 25 with limits 0 to 100 would return 75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Inclusive upper limit.</param>
    public static byte Flip(this byte value, byte min, byte max)
    {
        return (byte)((max + min) - value);
    }

    /// <summary>
    /// Flips a value within limits.
    /// Example: 25 with limits 0 to 100 would return 75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Inclusive upper limit.</param>
    public static ushort Flip(this ushort value, ushort min, ushort max)
    {
        return (ushort)((max + min) - value);
    }

    /// <summary>
    /// Flips a value within limits.
    /// Example: 25 with limits 0 to 100 would return 75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Inclusive upper limit.</param>
    public static short Flip(this short value, short min, short max)
    {
        return (short)((max + min) - value);
    }

    /// <summary>
    /// Flips a value within limits.
    /// Example: 25 with limits 0 to 100 would return 75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Inclusive upper limit.</param>
    public static uint Flip(this uint value, uint min, uint max)
    {
        return (max + min) - value;
    }

    /// <summary>
    /// Flips a value within limits.
    /// Example: 25 with limits 0 to 100 would return 75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Inclusive upper limit.</param>
    public static int Flip(this int value, int min, int max)
    {
        return (max + min) - value;
    }

    /// <summary>
    /// Flips a value within limits.
    /// Example: 25 with limits 0 to 100 would return 75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Inclusive upper limit.</param>
    public static ulong Flip(this ulong value, ulong min, ulong max)
    {
        return (max + min) - value;
    }

    /// <summary>
    /// Flips a value within limits.
    /// Example: 25 with limits 0 to 100 would return 75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Inclusive upper limit.</param>
    public static long Flip(this long value, long min, long max)
    {
        return (max + min) - value;
    }

    /// <summary>
    /// Flips a value within limits.
    /// Example: 0.25 with limits 0 to 1 would return 0.75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Inclusive upper limit.</param>
    public static float Flip(this float value, float min, float max)
    {
        return (max + min) - value;
    }

    /// <summary>
    /// Flips a value within limits.
    /// Example: 0.25 with limits 0 to 1 would return 0.75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Inclusive upper limit.</param>
    public static double Flip(this double value, double min, double max)
    {
        return (max + min) - value;
    }

    /// <summary>
    /// Flips a value within limits.
    /// Example: 0.25 with limits 0 to 1 would return 0.75.
    /// </summary>
    /// <param name="value">Value to flip.</param>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Inclusive upper limit.</param>
    public static decimal Flip(this decimal value, decimal min, decimal max)
    {
        return (max + min) - value;
    }
}
