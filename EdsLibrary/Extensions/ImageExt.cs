namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Image"/> type.
/// </summary>
public static partial class ImageExt
{
    /// <summary>
    /// Transforms an image into a byte array.
    /// </summary>
    public static byte[] ToByteArray(this Image image)
    {
        ImageConverter _imageConverter = new();
        byte[] xByte = (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
        return xByte;
    }
}
