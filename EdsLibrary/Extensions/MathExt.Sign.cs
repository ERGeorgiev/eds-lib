namespace EdsLibrary.Extensions;

/// <summary>
/// Extension to the System.Math class.
/// </summary>
public static partial class MathExt
{
    /// <summary>
    /// Returns 1 if value is bigger or equal to 0 and -1 if values is less than 0.
    /// </summary>
    public static int Sign(this sbyte value)
    {
        return (value >= 0) ? 1 : -1;
    }

    /// <summary>
    /// Returns 1 if value is bigger or equal to 0 and -1 if values is less than 0.
    /// </summary>
    public static int Sign(this short value)
    {
        return (value >= 0) ? 1 : -1;
    }

    /// <summary>
    /// Returns 1 if value is bigger or equal to 0 and -1 if values is less than 0.
    /// </summary>
    public static int Sign(this int value)
    {
        return (value >= 0) ? 1 : -1;
    }

    /// <summary>
    /// Returns 1 if value is bigger or equal to 0 and -1 if values is less than 0.
    /// </summary>
    public static int Sign(this long value)
    {
        return (value >= 0) ? 1 : -1;
    }

    /// <summary>
    /// Returns 1 if value is bigger or equal to 0 and -1 if values is less than 0.
    /// </summary>
    public static int Sign(this float value)
    {
        return (value >= 0) ? 1 : -1;
    }

    /// <summary>
    /// Returns 1 if value is bigger or equal to 0 and -1 if values is less than 0.
    /// </summary>
    public static int Sign(this double value)
    {
        return (value >= 0) ? 1 : -1;
    }

    /// <summary>
    /// Returns 1 if value is bigger or equal to 0 and -1 if values is less than 0.
    /// </summary>
    public static int Sign(this decimal value)
    {
        return (value >= 0) ? 1 : -1;
    }
}
