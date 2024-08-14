using EdsLibrary.Enums;
using EdsLibrary.Extensions;

namespace EdsLibrary.Utility;

public static class IconEditor
{
    public static Icon Flip(Icon icon, Plane? plane = null) => icon.ToBitmap().Flip(plane).ToIcon();
    public static Icon Rotate(Icon icon, double angle) => icon.ToBitmap().Rotate(angle).ToIcon();
    public static Icon Overlay(Icon layer1, Icon layer2) => layer1.ToBitmap().Overlay(layer2.ToBitmap()).ToIcon();
}
