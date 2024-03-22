using EdsLibrary.Enums;
using EdsLibrary.Extensions;

namespace EdsLibrary.Utility;

public static class BitmapEditor
{
    public static Bitmap Move(Bitmap img, int offsetX, int offsetY)
    {
        var newImg = new Bitmap(img.Width, img.Height);

        offsetY *= -1;
        var xLimit = Math.Min(img.Width, img.Width + offsetX);
        var yLimit = Math.Min(img.Height, img.Height + offsetY);
        for (int x = Math.Max(offsetX, 0); x < xLimit; x++)
        {
            for (int y = Math.Max(offsetY, 0); y < yLimit; y++)
            {
                newImg.SetPixel(x, y, img.GetPixel(x - offsetX, y - offsetY));
            }
        }

        return newImg;
    }

    public static Bitmap Transpose(Bitmap img, int offsetX, int offsetY)
    {
        var newImg = new Bitmap(img.Width, img.Height);

        offsetY *= -1;
        for (int x = 0; x < img.Width; x++)
        {
            for (int y = 0; y < img.Height; y++)
            {
                newImg.SetPixel(x, y, img.GetPixel((x + offsetX).Mod(img.Width), (y + offsetY).Mod(img.Height)));
            }
        }

        return newImg;
    }

    public static Bitmap Rotate(Bitmap img, double angleInDegrees)
    {
        Color?[,] newImgArray = new Color?[img.Width, img.Height];
        var newImg = new Bitmap(img.Width, img.Height);

        var centerX = img.Width / 2D;
        var centerY = img.Height / 2D;
        var rad = Math.PI / 180 * angleInDegrees;
        var sinFi = Math.Sin(rad);
        var cosFi = Math.Cos(rad);
        for (int x = 0; x < img.Width; x++)
        {
            for (int y = 0; y < img.Height; y++)
            {
                var newX = (int)Math.Round(centerX + (x - centerX) * cosFi - (y - centerY) * sinFi);
                var newY = (int)Math.Round(centerY + (x - centerX) * sinFi + (y - centerY) * cosFi);
                if (newX.IsWithin(0, img.Width) && newY.IsWithin(0, img.Height))
                {
                    var pixel = img.GetPixel(x, y);
                    if (newImgArray[newX, newY] == null)
                    {
                        newImgArray[newX, newY] = pixel;
                    }
                    else
                    {
                        FillAnyBorderNull(newX, newY, pixel);
                    }
                }
            }
        }

        FixArtifacts();
        PrintMatrix();

        return newImg;

        void FillAnyBorderNull(int x, int y, Color color)
        {
            if (newImgArray[(x - 1).Limit(0, img.Width - 1), y] == null)
            {
                newImgArray[x - 1, y] = color;
            }
            else if (newImgArray[(x + 1).Limit(0, img.Width - 1), y] == null)
            {
                newImgArray[x + 1, y] = color;
            }
            else if (newImgArray[x, (y - 1).Limit(0, img.Height - 1)] == null)
            {
                newImgArray[x, y - 1] = color;
            }
            else if (newImgArray[x, (y + 1).Limit(0, img.Height - 1)] == null)
            {
                newImgArray[x, y + 1] = color;
            }
            else if (newImgArray[(x - 1).Limit(0, img.Width - 1), (y - 1).Limit(0, img.Height - 1)] == null)
            {
                newImgArray[x - 1, y - 1] = color;
            }
            else if (newImgArray[(x + 1).Limit(0, img.Width - 1), (y + 1).Limit(0, img.Height - 1)] == null)
            {
                newImgArray[x + 1, y + 1] = color;
            }
        }

        void FixArtifacts()
        {
            for (int x = 1; x < img.Width - 1; x++)
            {
                for (int y = 1; y < img.Height - 1; y++)
                {
                    if (newImgArray[x, y] == null
                        && newImgArray[x + 1, y] != null
                        && newImgArray[x - 1, y] != null
                        && newImgArray[x, y + 1] != null
                        && newImgArray[x, y - 1] != null)
                    {
                        var a = newImgArray[x + 1, y]!.Value.A + newImgArray[x - 1, y]!.Value.A + newImgArray[x, y + 1]!.Value.A + newImgArray[x, y - 1]!.Value.A;
                        var r = newImgArray[x + 1, y]!.Value.R + newImgArray[x - 1, y]!.Value.R + newImgArray[x, y + 1]!.Value.R + newImgArray[x, y - 1]!.Value.R;
                        var g = newImgArray[x + 1, y]!.Value.G + newImgArray[x - 1, y]!.Value.G + newImgArray[x, y + 1]!.Value.G + newImgArray[x, y - 1]!.Value.G;
                        var b = newImgArray[x + 1, y]!.Value.B + newImgArray[x - 1, y]!.Value.B + newImgArray[x, y + 1]!.Value.B + newImgArray[x, y - 1]!.Value.B;
                        newImgArray[x, y] = Color.FromArgb(a / 4, r / 4, g / 4, b / 4);
                    }
                }
            }
        }

        void PrintMatrix()
        {
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    if (newImgArray[x, y] != null)
                    {
                        newImg.SetPixel(x, y, newImgArray[x, y]!.Value);
                    }
                }
            }
        }
    }

    public static Bitmap Flip(Bitmap img, Plane? plane = null)
    {
        var newImg = new Bitmap(img.Width, img.Height);

        switch (plane)
        {
            case Plane.Horizontal:
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        newImg.SetPixel(x, y, img.GetPixel(x.Flip(0, img.Width - 1), y));
                    }
                }
                break;
            case Plane.Vertical:
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        newImg.SetPixel(x, y, img.GetPixel(x, y.Flip(0, img.Height - 1)));
                    }
                }
                break;
            case null:
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        newImg.SetPixel(x, y, img.GetPixel(x.Flip(0, img.Width - 1), y.Flip(0, img.Height - 1)));
                    }
                }
                break;
            default:
                break;
        }

        return newImg;
    }
}
