using EdsLibrary.Enums;
using EdsLibrary.Utility;

namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Bitmap"/> type.
/// </summary>
public static partial class BitmapExt
{
    public static Lazy<Bitmap> Blank = new(() => BitmapEditor.Generate(new Size(16, 16), Color.Magenta));
    public static Lazy<Bitmap> Transparent = new(() => BitmapEditor.Generate(new Size(16, 16), Color.Transparent));

    public static Icon ToIcon(this Bitmap img) => Icon.FromHandle(img.GetHicon());
    public static Bitmap Move(this Bitmap img, int moveX, int moveY) => BitmapEditor.Move(img, moveX, moveY);
    public static Bitmap MoveInLoop(this Bitmap img, int moveX, int moveY) => BitmapEditor.Transpose(img, moveX, moveY);
    public static Bitmap Rotate(this Bitmap img, double angle) => BitmapEditor.Rotate(img, angle);
    public static Bitmap Flip(this Bitmap img, Plane? plane = null) => BitmapEditor.Flip(img, plane);
    public static Bitmap Overlay(this Bitmap img, Bitmap overlay) => BitmapEditor.Overlay(img, overlay);
    public static Bitmap CloneBitmap(this Bitmap bmp) => bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), bmp.PixelFormat);

    /// <summary>
    /// Load an image from a file. Returns a blank fallback image on failure.
    /// </summary>
    public static Bitmap FromStreamSafe(Stream? stream)
    {
        if (stream == null) return Blank.Value;

        try
        {
            return new Bitmap(stream);
        }
        catch (Exception e)
        {
            Logger.LogError($"Failed to load image from stream.", e);
            return Blank.Value;
        }
    }
}
