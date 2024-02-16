using System;
using System.Collections.Generic;
using System.Reflection;

namespace EdsLibrary;

/// <summary>
/// Sources:
/// https://stackoverflow.com/questions/12680341/how-to-get-both-fields-and-properties-in-single-call-via-reflection
/// James Newton-King, http://www.newtonsoft.com
/// </summary>
public static partial class MemberInfoExt
{
    public static void SetValues<T>(this MemberInfo[] members, object obj, object value)
    {
        for (int i = 0; i < members.Length; i++)
        {
            if (members[i].GetTypeExt() == typeof(T))
            {
                members[i].SetValue(obj, value);
            }
        }
    }

    public static T[] GetValues<T>(this MemberInfo[] members, object obj)
    {
        List<T> properties = new List<T>();

        for (int i = 0; i < members.Length; i++)
        {
            if (members[i].GetTypeExt() == typeof(T))
            {
                properties.Add((T)members[i].GetValue(obj));
            }
        }

        return properties.ToArray();
    }

    public static void SetValue(this MemberInfo member, object obj, object value)
    {
        if (member.MemberType == MemberTypes.Property)
            ((PropertyInfo)member).SetValue(obj, value, null);
        else if (member.MemberType == MemberTypes.Field)
            ((FieldInfo)member).SetValue(obj, value);
    }

    public static object GetValue(this MemberInfo member, object obj)
    {
        if (member.MemberType == MemberTypes.Property)
            return ((PropertyInfo)member).GetValue(obj, null);
        else if (member.MemberType == MemberTypes.Field)
            return ((FieldInfo)member).GetValue(obj);
        else
            return null;
    }

    public static Type GetTypeExt(this MemberInfo member)
    {
        switch (member.MemberType)
        {
            case MemberTypes.Field:
                return ((FieldInfo)member).FieldType;
            case MemberTypes.Property:
                return ((PropertyInfo)member).PropertyType;
            case MemberTypes.Event:
                return ((EventInfo)member).EventHandlerType;
            case MemberTypes.NestedType:
                return typeof(object[]);
            default:
                return typeof(object);
        }
    }
}
