namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Image"/> type.
/// </summary>
public static partial class ImageExt
{
    public static Lazy<Image> Blank = new(() => BitmapExt.Blank.Value);

    /// <summary>
    /// Low quality conversion. Finding a high quality conversion proved difficult.
    /// </summary>
    public static Icon ToIcon(this Image img) => new Bitmap(img).ToIcon();

    /// <summary>
    /// Transforms an image into a byte array.
    /// </summary>
    public static byte[] ToByteArray(this Image image)
    {
        ImageConverter _imageConverter = new();
        byte[] xByte = (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
        return xByte;
    }

    /// <summary>
    /// Load an image from a file. Returns a blank fallback image on failure.
    /// </summary>
    public static Image FromFileSafe(this string? filepath)
    {
        if (string.IsNullOrEmpty(filepath)) return Blank.Value;

        try
        {
            return Image.FromFile(filepath);
        }
        catch (Exception e)
        {
            Logger.LogError($"Failed to load image '{filepath}'", e);
            return Blank.Value;
        }
    }

    /// <summary>
    /// Load an image from a file. Returns a blank fallback image on failure.
    /// </summary>
    public static Image FromStreamSafe(Stream? stream)
    {
        if (stream == null) return Blank.Value;

        try
        {
            return Image.FromStream(stream);
        }
        catch (Exception e)
        {
            Logger.LogError($"Failed to load image from stream.", e);
            return Blank.Value;
        }
    }
}
