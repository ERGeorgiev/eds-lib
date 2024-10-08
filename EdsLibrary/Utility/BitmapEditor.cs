﻿using EdsLibrary.Enums;
using EdsLibrary.Extensions;
using System.Drawing.Imaging;

namespace EdsLibrary.Utility;

// Note: 0,0 is top left
// Note: Bitmap.Clone(..) is pretty fast.
// ToDo: To test g.Draw vs SetPixel for a whole 16x16 bitmap to see which is faster and why and in which scenarios.
public static class BitmapEditor
{
    public static Bitmap Combine(Plane plane, params Bitmap[] bitmaps)
    {
        Bitmap canvas;
        if (plane == Plane.Horizontal)
            canvas = new Bitmap(bitmaps.Sum(b => b.Width), bitmaps.Max(b => b.Height));
        else
            canvas = new Bitmap(bitmaps.Max(b => b.Width), bitmaps.Sum(b => b.Height));

        using Graphics g = Graphics.FromImage(canvas);
        int offsetX = 0;
        int offsetY = 0;
        for (int i = 0; i < bitmaps.Length; i++)
        {
            var b = bitmaps[i];
            g.DrawImage(b, new Rectangle(offsetX, offsetY, b.Width, b.Height));
            if (plane == Plane.Horizontal) offsetX += b.Width;
            else if (plane == Plane.Vertical) offsetY += b.Height;
        }

        return canvas;
    }

    public static Bitmap Scale(Bitmap bitmap, float scale) 
        => new(bitmap, (int)Math.Round(bitmap.Width * scale), (int)Math.Round(bitmap.Height * scale));

    public static Bitmap CanvasIncrement(Bitmap bmp, int top = 0, int bottom = 0, int left = 0, int right = 0)
    {
        var totalWidthIncrement = left + right;
        var totalHeightIncrement = top + bottom;
        if (totalWidthIncrement <= -bmp.Width) throw new ArgumentOutOfRangeException("Total width increment cannot set the image to less than 1 pixel width.");
        if (totalHeightIncrement <= -bmp.Height) throw new ArgumentOutOfRangeException("Total height increment cannot set the image to less than 1 pixel height.");
        var canvas = new Bitmap(bmp.Width + totalWidthIncrement, bmp.Height + totalHeightIncrement);

        var trimmedX = left < 0 ? Math.Abs(left) : 0;
        var trimmedY = top < 0 ? Math.Abs(top) : 0;
        var widthLoss = right < 0 ? Math.Abs(right) : 0;
        var heightLoss = bottom < 0 ? Math.Abs(bottom) : 0;
        var width = bmp.Width - trimmedX - widthLoss;
        var height = bmp.Height - trimmedY - heightLoss;
        var overlay = bmp.Clone(new Rectangle(trimmedX, trimmedY, width, height), bmp.PixelFormat);

        using Graphics g = Graphics.FromImage(canvas);
        int offsetX = left > 0 ? left : 0;
        int offsetY = top > 0 ? top : 0;
        g.DrawImage(overlay, new Rectangle(offsetX, offsetY, overlay.Width, overlay.Height));

        return canvas;
    }

    public static Bitmap Overlay(params Bitmap[] layers)
    {
        if (layers.Length == 0) throw new ArgumentException("No layers provided.", nameof(layers));
        Bitmap canvas = new(layers.Max(l => l.Width), layers.Max(l => l.Height));
        using Graphics g = Graphics.FromImage(canvas);
        foreach (Bitmap layer in layers)
        {
            int offsetX = (canvas.Width - layer.Width) / 2;
            int offsetY = (canvas.Height - layer.Height) / 2;
            g.DrawImage(layer, offsetX, offsetY);
        }

        return canvas;
    }

    public static Bitmap Overlay(params KeyValuePair<Bitmap, Point>[] layersAndOffset)
    {
        if (layersAndOffset.Length == 0) throw new ArgumentException("No layers provided.", nameof(layersAndOffset));
        Bitmap canvas = new(layersAndOffset.Max(l => l.Key.Width + Math.Abs(l.Value.X)), layersAndOffset.Max(l => l.Key.Height + Math.Abs(l.Value.Y)));
        using Graphics g = Graphics.FromImage(canvas);
        foreach (var layer in layersAndOffset)
        {
            int offsetX = (canvas.Width - layer.Key.Width) / 2 + layer.Value.X;
            int offsetY = (canvas.Height - layer.Key.Height) / 2 + layer.Value.Y;
            g.DrawImage(layer.Key, offsetX, offsetY);
        }

        return canvas;
    }

    [Obsolete("Not Optimized", error: false)] // Not optimized using BitmapQuickEdit or Graphics.DrawImage
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

    public static void SetOpacity(Bitmap img, float percent)
    {
        var editor = new BitmapQuickEdit(img, ImageLockMode.WriteOnly);
        editor.SetOpacity(percent);
        editor.Lock();
    }

    [Obsolete("Not Optimized", error: false)] // Not optimized using BitmapQuickEdit or Graphics.DrawImage
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

    [Obsolete("Not Optimized", error: false)] // Not optimized using BitmapQuickEdit or Graphics.DrawImage
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

    [Obsolete("Not Optimized", error: false)] // Not optimized using BitmapQuickEdit or Graphics.DrawImage
    public static Bitmap Overlay(Bitmap layer, Bitmap overlay, CornerAnchor startingPosition = CornerAnchor.TopLeft)
    {
        var canvas = new Bitmap(layer.Width, layer.Height);

        for (int x = 0; x < layer.Width; x++)
        {
            for (int y = 0; y < layer.Height; y++)
            {
                var color = layer.GetPixel(x, y);
                var overlayColor = GetCorrespondingOverlayPixel(x, y);
                if (overlayColor != null && overlayColor.Value.A != 0)
                {
                    color = color.Merge(overlayColor.Value);
                }
                canvas.SetPixel(x, y, color);
            }
        }

        return canvas;

        Color? GetCorrespondingOverlayPixel(int x, int y)
        {
            if (startingPosition == CornerAnchor.TopRight || startingPosition == CornerAnchor.BottomRight) x -= (canvas.Width - overlay.Width);
            if (startingPosition == CornerAnchor.BottomLeft || startingPosition == CornerAnchor.BottomRight) y -= (canvas.Height - overlay.Height);

            if (x > 0 && y > 0 && x < overlay.Width && y < overlay.Height)
            {
                return overlay.GetPixel(x, y);
            }

            return null;
        }
    }

    [Obsolete("Not Optimized", error: false)] // Not optimized using BitmapQuickEdit or Graphics.DrawImage
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

    [Obsolete("Not Optimized", error: false)] // Not optimized using BitmapQuickEdit or Graphics.DrawImage
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
    [Obsolete("Not Optimized", error: false)] // Not optimized using BitmapQuickEdit or Graphics.DrawImage
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

    // ToDo: None of these methods are thread safe, as trying to GetPixel on Bitmap that is in use elsewhere throws and error.
    [Obsolete("Not Optimized", error: false)] // Not optimized using BitmapQuickEdit or Graphics.DrawImage
    public static Bitmap Grayscale(Bitmap img)
    {
        var newImg = new Bitmap(img.Width, img.Height);
        for (int x = 0; x < img.Width; x++)
        {
            for (int y = 0; y < img.Height; y++)
            {
                var pixel = img.GetPixel(x, y);
                if (pixel.A == 0)
                {
                    newImg.SetPixel(x, y, Color.Transparent);
                }
                else
                {
                    var gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    newImg.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
        }
        return newImg;
    }
}
