using EdsLibrary.Enums;
using EdsLibrary.Extensions;

namespace EdsLibrary.Utility;

public static class IconEditor
{
    public static Icon Flip(Icon icon, Plane? plane = null)
    {
        using var newIcon = icon.ToBitmap().Flip(plane);
        return newIcon.ToIcon();
    }
}
