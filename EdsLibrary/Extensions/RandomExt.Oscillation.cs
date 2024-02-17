namespace EdsLibrary.Extensions;

/// <summary>
/// Extension to the System.Random class.
/// </summary>
public static partial class RandomExt
{
    ///<summary>
    ///Randomizes value from -value to +value.
    ///</summary>
    public static double Oscillation(sbyte value)
    {
        return value * Shared.Next(-1, 1);
    }

    ///<summary>
    ///Randomizes value from -value to +value.
    ///</summary>
    public static double Oscillation(byte value)
    {
        return value * Shared.Next(-1, 1);
    }

    ///<summary>
    ///Randomizes value from -value to +value.
    ///</summary>
    public static double Oscillation(ushort value)
    {
        return value * Shared.Next(-1, 1);
    }

    ///<summary>
    ///Randomizes value from -value to +value.
    ///</summary>
    public static double Oscillation(short value)
    {
        return value * Shared.Next(-1, 1);
    }

    ///<summary>
    ///Randomizes value from -value to +value.
    ///</summary>
    public static double Oscillation(uint value)
    {
        return value * Shared.Next(-1, 1);
    }

    ///<summary>
    ///Randomizes value from -value to +value.
    ///</summary>
    public static double Oscillation(int value)
    {
        return value * Shared.Next(-1, 1);
    }

    ///<summary>
    ///Randomizes value from -value to +value.
    ///</summary>
    public static double Oscillation(ulong value)
    {
        return (long)value * Shared.Next(-1, 1);
    }

    ///<summary>
    ///Randomizes value from -value to +value.
    ///</summary>
    public static double Oscillation(long value)
    {
        return value * Shared.Next(-1, 1);
    }

    ///<summary>
    ///Randomizes value from -value to +value.
    ///</summary>
    public static float Oscillation(float value)
    {
        return value * Shared.Next(-1, 1);
    }

    ///<summary>
    ///Randomizes value from -value to +value.
    ///</summary>
    public static double Oscillation(double value)
    {
        return value * Shared.Next(-1, 1);
    }

    ///<summary>
    ///Randomizes value from -value to +value.
    ///</summary>
    public static decimal Oscillation(decimal value)
    {
        return value * Shared.Next(-1, 1);
    }
}
