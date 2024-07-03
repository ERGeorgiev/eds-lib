namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Color"/> type.
/// </summary>
public static partial class ColorExt
{
    public static Color Merge(this Color a, Color b)
    {
        var alpha = 255 - ((255 - a.A) * (255 - b.A) / 255);
        var red = (a.R * (255 - b.A) + b.R * b.A) / 255;
        var green = (a.G * (255 - b.A) + b.G * b.A) / 255;
        var blue = (a.B * (255 - b.A) + b.B * b.A) / 255;

        return Color.FromArgb(alpha, red, green, blue);
    }
}
