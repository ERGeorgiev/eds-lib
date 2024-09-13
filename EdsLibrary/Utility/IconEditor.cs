using EdsLibrary.Enums;
using EdsLibrary.Extensions;

namespace EdsLibrary.Utility;

public static class IconEditor
{
    public static Icon Flip(Icon icon, Plane? plane = null) => icon.ToBitmap().Flip(plane).ToIcon();
    public static Icon Rotate(Icon icon, double angle) => icon.ToBitmap().Rotate(angle).ToIcon();

    // ToDo: This causes GDI crash. Maybe because of multi-threading in IconEditor.
    // Tho now I was not doing anything and it still crashed. Is it a memory issue, as it seems to happen overtime? Idk..
    // https://stackoverflow.com/questions/1053052/a-generic-error-occurred-in-gdi-jpeg-image-to-memorystream
    // Maybe use Icon.Clone
    [Obsolete("Unstable, may cause crashes.")]
    public static Icon Overlay(Icon layer1, Icon layer2) => layer1.ToBitmap().Overlay(layer2.ToBitmap()).ToIcon();
}
