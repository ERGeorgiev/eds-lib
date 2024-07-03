using EdsLibrary.Enums;
using EdsLibrary.Utility;

namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Bitmap"/> type.
/// </summary>
public static partial class BitmapExt
{
    public static Lazy<Bitmap> Blank = new(() => GetMagentaSquare());

    public static Icon ToIcon(this Bitmap img) => Icon.FromHandle(img.GetHicon());
    public static Image ToImage(this Bitmap img) => Image.FromHbitmap(img.GetHbitmap());
    public static Bitmap Move(this Bitmap img, int moveX, int moveY) => BitmapEditor.Move(img, moveX, moveY);
    public static Bitmap MoveInLoop(this Bitmap img, int moveX, int moveY) => BitmapEditor.Transpose(img, moveX, moveY);
    public static Bitmap Rotate(this Bitmap img, double angle) => BitmapEditor.Rotate(img, angle);
    public static Bitmap Flip(this Bitmap img, Plane? plane = null) => BitmapEditor.Flip(img, plane);
    public static Bitmap Overlay(this Bitmap img, Bitmap overlay) => BitmapEditor.Overlay(img, overlay);

    /// <summary>
    /// Generates a simple bitmap.
    /// </summary>
    public static Bitmap Generate(Size size, Color? color = null)
    {
        var newImg = new Bitmap(size.Width, size.Height);

        if (color != null)
        {
            for (int x = 0; x < size.Width; x++)
            {
                for (int y = 0; y < size.Height; y++)
                {
                    newImg.SetPixel(x, y, color.Value);
                }
            }
        }

        return newImg;
    }

    private static Bitmap GetMagentaSquare()
    {
        var newImg = new Bitmap(16, 16);

        for (int x = 0; x < newImg.Width; x++)
        {
            for (int y = 0; y < newImg.Height; y++)
            {
                newImg.SetPixel(x, y, Color.Magenta);
            }
        }

        return newImg;
    }
}
