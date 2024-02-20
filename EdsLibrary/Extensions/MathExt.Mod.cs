namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Math"/> type.
/// </summary>
public static partial class MathExt
{
    /// <summary>
    /// Performs the module operation on a value.
    /// Example: 3%10 = 3; 11%10 = 1; -2%5 = 3;
    /// </summary>
    public static sbyte Mod(this double value, double mod)
    {
        return (sbyte)(value - mod * Math.Floor(value / mod));
    }

    /// <summary>
    /// Performs the module operation on a value.
    /// Example: 3%10 = 3; 11%10 = 1; -2%5 = 3;
    /// </summary>
    public static byte Mod(this byte value, int mod)
    {
        return (byte)(value - mod * (value / mod));
    }

    /// <summary>
    /// Performs the module operation on a value.
    /// Example: 3%10 = 3; 11%10 = 1; -2%5 = 3;
    /// </summary>
    public static ushort Mod(this ushort value, int mod)
    {
        return (ushort)(value - mod * (value / mod));
    }

    /// <summary>
    /// Performs the module operation on a value.
    /// Example: 3%10 = 3; 11%10 = 1; -2%5 = 3;
    /// </summary>
    public static short Mod(this short value, int mod)
    {
        return (short)(value - mod * (value / mod));
    }

    /// <summary>
    /// Performs the module operation on a value.
    /// Example: 3%10 = 3; 11%10 = 1; -2%5 = 3;
    /// </summary>
    public static uint Mod(this uint value, int mod)
    {
        return (uint)(value - mod * (value / mod));
    }

    /// <summary>
    /// Performs the module operation on a value.
    /// Example: 3%10 = 3; 11%10 = 1; -2%5 = 3;
    /// </summary>
    public static int Mod(this int value, int mod)
    {
        int r = value % mod;
        return r < 0 ? r + mod : r;
    }

    /// <summary>
    /// Performs the module operation on a value.
    /// Example: 3%10 = 3; 11%10 = 1; -2%5 = 3;
    /// </summary>
    public static ulong Mod(this ulong value, ulong mod)
    {
        return (ulong)(value - mod * (value / mod));
    }

    /// <summary>
    /// Performs the module operation on a value.
    /// Example: 3%10 = 3; 11%10 = 1; -2%5 = 3;
    /// </summary>
    public static long Mod(this long value, int mod)
    {
        return value - mod * (value / mod);
    }

    /// <summary>
    /// Performs the module operation on a value.
    /// Example: 3%10 = 3; 11%10 = 1; -2%5 = 3;
    /// </summary>
    public static float Mod(this float value, int mod)
    {
        return value - mod * (value / mod);
    }

    /// <summary>
    /// Performs the module operation on a value.
    /// Example: 3%10 = 3; 11%10 = 1; -2%5 = 3;
    /// </summary>
    public static double Mod(this double value, int mod)
    {
        return value - mod * (value / mod);
    }

    /// <summary>
    /// Performs the module operation on a value.
    /// Example: 3%10 = 3; 11%10 = 1; -2%5 = 3;
    /// </summary>
    public static decimal Mod(this decimal value, int mod)
    {
        return value - mod * (value / mod);
    }
}
