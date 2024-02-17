namespace EdsLibrary.Extensions;
/// <summary>
/// Extension to the System.String class.
/// </summary>
public static partial class StringExt
{
    /// <summary>
    /// Truncates a string to the desired length.
    /// </summary>
    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }

    /// <summary>
    /// Surrounds the value with the given surrounding value.
    /// </summary>
    public static string SurroundWith(this string value, string surroundingValue)
    {
        return surroundingValue + value + surroundingValue;
    }
}
