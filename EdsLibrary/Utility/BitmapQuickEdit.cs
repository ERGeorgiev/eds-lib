using EdsLibrary.Extensions;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace EdsLibrary.Utility;

// Note: argbValues is in format BGRA (Blue, Green, Red, Alpha)
public class BitmapQuickEdit : IDisposable
{
    private readonly Bitmap _bitmap;
    private readonly BitmapData _data;

    public BitmapQuickEdit(Bitmap bmp, ImageLockMode lockMode)
    {
        if (bmp.PixelFormat.ToString().ToLowerInvariant().Contains("argb") == false)
            throw new NotImplementedException("Only ARGB pixel formats accepted.");

        _bitmap = bmp;
        _data = _bitmap.LockBits(new Rectangle(Point.Empty, _bitmap.Size), lockMode, _bitmap.PixelFormat);
        Width = _data.Width;
        Height = _data.Height;

        int imgBytes = Math.Abs(_data.Stride) * Height;
        Values = new byte[imgBytes];

        // Copy the RGB values into the array.
        Marshal.Copy(_data.Scan0, Values, 0, Values.Length);

    }

    public int Width { get; }
    public int Height { get; }
    public byte[] Values { get; set; }
    public bool Locked { get; private set; }

    public Color GetPixel(int x, int y)
    {
        var index = (x + y * Width) * 4;

        try
        {
            return Color.FromArgb(Values[index], Values[index + 1], Values[index + 2], Values[index + 3]);
        }
        catch
        {
            throw new ArgumentOutOfRangeException("x or y", "Pixel does not exist at the given x or y");
        }

    }

    public void SetPixel(int x, int y, Color color)
    {
        var index = y * Width * 4; // (* 4) for ARGB as each one of those is a byte.
        index += x * 4;

        try
        {
            Values[index] = color.A;
            Values[index + 1] = color.R;
            Values[index + 2] = color.G;
            Values[index + 3] = color.B;
        }
        catch
        {
            throw new ArgumentOutOfRangeException("x or y", "Pixel does not exist at the given x or y");
        }
    }

    public void SetOpacity(float percent)
    {
        for (int i = 0; i < Values.Length; i += 4)
        {
            var currentA = Values[i + 3];
            if (currentA > 0)
            {
                var newA = (byte)(255 * percent);
                for (int j = 0; j < 3; j++)
                {
                    Values[i + j] = (byte)Math.Round(Values[i + j] / (float)currentA * newA).Limit(0, 255);
                }
                // Values[i + 3] = newA; // Seems like no need to adjust alpha when changing opacity.
            }
        }
    }

    public void SetAlpha(byte a)
    {
        for (int i = 3; i < Values.Length; i += 4)
        {
            if (Values[i] != 0) Values[i] = a;
        }
    }

    public void Lock()
    {
        if (Locked) throw new InvalidOperationException("Already locked.");
        Locked = true;

        // Copy the RGB values back to the bitmap
        Marshal.Copy(Values, 0, _data.Scan0, Values.Length);

        _bitmap.UnlockBits(_data);
    }

    public void Dispose()
    {
        if (Locked == false) Lock();
    }
}
