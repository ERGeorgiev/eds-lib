using System.Reflection;

namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="MemberInfo"/> type.
/// </summary>
public static partial class MemberInfoExt
{
    public static void SetValue(this MemberInfo member, object obj, object value)
    {
        if (member.MemberType == MemberTypes.Property)
            ((PropertyInfo)member).SetValue(obj, value, null);
        else if (member.MemberType == MemberTypes.Field)
            ((FieldInfo)member).SetValue(obj, value);
    }

    public static object? GetValue(this MemberInfo member, object obj)
    {
        if (member.MemberType == MemberTypes.Property)
            return ((PropertyInfo)member).GetValue(obj, null);
        else if (member.MemberType == MemberTypes.Field)
            return ((FieldInfo)member).GetValue(obj);
        else
            return null;
    }

    public static Type? GetMemberType(this MemberInfo member)
    {
        return member.MemberType switch
        {
            MemberTypes.Field => ((FieldInfo)member).FieldType,
            MemberTypes.Property => ((PropertyInfo)member).PropertyType,
            _ => null,
        };
    }
}
