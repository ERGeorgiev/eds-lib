namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Image"/> type.
/// </summary>
public static partial class ImageExt
{
    public static Lazy<Image> Blank = new(() => BitmapExt.Blank.Value.ToImage());

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
    public static Image FromFileSafe(this string filepath)
    {
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
}
