namespace EdsLibrary.Extensions;

public static partial class TypeExt
{
    public static bool IsSystemType(this Type type)
    {
        return (type.Assembly.GetName().Name == "mscorlib");
    }
}
