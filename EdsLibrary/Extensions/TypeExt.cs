namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Type"/> type.
/// </summary>
public static partial class TypeExt
{
    public static bool IsSystemType(this Type type)
    {
        return type.Assembly.GetName().Name == "mscorlib";
    }
}
