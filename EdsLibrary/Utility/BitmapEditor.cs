using EdsLibrary.Enums;
using EdsLibrary.Extensions;

namespace EdsLibrary.Utility;

public static class BitmapEditor
{
    public static Bitmap Combine(Plane plane, params Bitmap[] b)
    {
        var width = b[0].Width;
        var height = b[0].Height;
        if (plane == Plane.Horizontal)
        {
            foreach (var bitmap in b)
            {
                if (bitmap.Size.Height != height)
                {
                    throw new ArgumentOutOfRangeException($"Bitmaps must be the same height to combine on Plane '{plane}'.");
                }
            }
        }
        if (plane == Plane.Vertical)
        {
            foreach (var bitmap in b)
            {
                if (bitmap.Size.Width != width)
                {
                    throw new ArgumentOutOfRangeException($"Bitmaps must be the same width to combine on Plane '{plane}'.");
                }
            }
        }

        Bitmap newImg;
        if (plane == Plane.Horizontal)
        {
            newImg = new Bitmap(b.Sum(b => b.Width), height);
        }
        else
        {
            newImg = new Bitmap(width, b.Sum(b => b.Height));
        }

        var startX = 0;
        var startY = 0;
        foreach (var bitmap in b)
        {
            Add(newImg, bitmap, startX, startY);
            if (plane == Plane.Horizontal) startX += bitmap.Size.Width;
            if (plane == Plane.Vertical) startY += bitmap.Size.Height;
        }

        // 0,0 is top left
        void Add(Bitmap canvas, Bitmap toAdd, int startX, int startY)
        {
            for (int x = 0; x < toAdd.Width; x++)
            {
                for (int y = 0; y < toAdd.Height; y++)
                {
                    canvas.SetPixel(x + startX, y + startY, toAdd.GetPixel(x, y));
                }
            }
        }

        return newImg;
    }

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

    public static Bitmap SetOpacity(Bitmap img, float opacity)
    {
        var newImg = new Bitmap(img.Width, img.Height);

        for (int x = 0; x < img.Width; x++)
        {
            for (int y = 0; y < img.Height; y++)
            {
                var pixel = img.GetPixel(x, y);
                pixel = pixel.SetOpacity(opacity);
                newImg.SetPixel(x, y, pixel);
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

    public static Bitmap[] ExtractSpreadsheet(Bitmap spreadsheet, Size singleImageSize)
    {
        if (singleImageSize.Width == 0 || singleImageSize.Height == 0)
            throw new ArgumentException($"Both the width and the height of the selected size must be bigger than 0.");
        if (spreadsheet.Width % singleImageSize.Width != 0)
            throw new ArgumentOutOfRangeException($"The spreadsheet width ({spreadsheet.Width}) must be multiple of the size width ({singleImageSize.Width})");
        if (spreadsheet.Height % singleImageSize.Height != 0)
            throw new ArgumentOutOfRangeException($"The spreadsheet width ({spreadsheet.Height}) must be multiple of the size width ({singleImageSize.Height})");

        int cols = spreadsheet.Width / singleImageSize.Width;
        int rows = spreadsheet.Height / singleImageSize.Height;
        var canvases = new List<Bitmap>();

        for (int c = 0; c < cols; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                var canvas = new Bitmap(singleImageSize.Width, singleImageSize.Height);
                var canvasIsFullyTransparent = true;
                for (int x = 0; x < canvas.Width; x++)
                {
                    var spreadsheetX = x + (c * singleImageSize.Width);
                    for (int y = 0; y < canvas.Height; y++)
                    {
                        var spreadsheetY = y + (r * singleImageSize.Height);
                        var spreadsheetPixel = spreadsheet.GetPixel(spreadsheetX, spreadsheetY);
                        if (spreadsheetPixel != Color.Transparent)
                        {
                            canvas.SetPixel(x, y, spreadsheet.GetPixel(spreadsheetX, spreadsheetY));
                            canvasIsFullyTransparent = false;
                        }
                    }
                }
                if (canvasIsFullyTransparent == false) canvases.Add(canvas);
            }
        }

        return canvases.ToArray();
    }

    public static Bitmap Overlay(Bitmap layer, Bitmap overlay, OverlayAnchor startingPosition = OverlayAnchor.TopLeft)
    {
        var canvas = new Bitmap(layer.Width, layer.Height);

        for (int x = 0; x < layer.Width; x++)
        {
            for (int y = 0; y < layer.Height; y++)
            {
                var color = layer.GetPixel(x, y);
                if (x < overlay.Width && y < overlay.Height)
                {
                    var overlayColor = GetCorrespondingOverlayPixel(x, y);
                    if (overlayColor != null && overlayColor != Color.Transparent)
                    {
                        color = color.Merge(overlayColor.Value);
                    }
                }
                canvas.SetPixel(x, y, color);
            }
        }

        return canvas;

        Color? GetCorrespondingOverlayPixel(int x, int y)
        {
            if (startingPosition == OverlayAnchor.TopRight || startingPosition == OverlayAnchor.BottomRight) x -= (canvas.Width - overlay.Width);
            if (startingPosition == OverlayAnchor.BottomLeft || startingPosition == OverlayAnchor.BottomRight) y -= (canvas.Height - overlay.Height);

            if (x > 0 && y > 0 && x < overlay.Width && y < overlay.Height)
            {
                return overlay.GetPixel(x, y);
            }

            return null;
        }
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

    public enum OverlayAnchor
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
    }
}
