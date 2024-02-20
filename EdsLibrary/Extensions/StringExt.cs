namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="string"/> type.
/// </summary>
public static partial class StringExt
{
    /// <summary>
    /// Truncates a string to the desired length.
    /// </summary>
    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        if (maxLength == 0) return string.Empty;
        if (maxLength < 0) throw new ArgumentOutOfRangeException(nameof(maxLength));

        return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }

    /// <summary>
    /// Surrounds a string with a given value.
    /// </summary>
    public static string SurroundWith(this string value, string surroundingValue)
    {
        return surroundingValue + value + surroundingValue;
    }
}
