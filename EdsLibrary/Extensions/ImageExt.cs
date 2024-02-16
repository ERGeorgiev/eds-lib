namespace EdsLibrary.Extensions;

/// <summary>
/// Extension to the Image class.
/// </summary>
public static partial class ImageExt
{
    /// <summary>
    /// Transforms an image into a byte array.
    /// </summary>
    public static byte[] ToByteArray(this Image image)
    {
        using (var ms = new MemoryStream())
        {
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
    }

    /// <summary>
    /// Transforms an image into a float array.
    /// </summary>
    public static float[] ToFloatArray(this Image image)
    {
        byte[] byteArray = image.ToByteArray();
        float[] floatArray = new float[byteArray.Length];

        for (int i = 0; i < byteArray.Length; i++)
        {
            floatArray[i] = byteArray[i] / 255f;
        }

        return floatArray;
    }
}
