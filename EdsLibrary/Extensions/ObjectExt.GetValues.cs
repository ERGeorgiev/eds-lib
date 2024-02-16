using System.Reflection;

namespace EdsLibrary.Extensions;

public static partial class ObjectExt
{
    /// <summary>
    /// Get all type values in fields and properties within a class.
    /// </summary>
    public static T[] GetTypeValues<T>(this object parent)
    {
        return parent.GetType().GetMembers().GetValues<T>(parent);
    }

    /// <summary>
    /// Get all type values in fields and properties within a class.
    /// </summary>
    public static T[] GetTypeValues<T>(this object parent, BindingFlags bindingAttr)
    {
        return parent.GetType().GetMembers(bindingAttr).GetValues<T>(parent);
    }

    /// <summary>
    /// Get all properties of type and branch to fields and their fields and etc.
    /// </summary>
    public static T[] GetTypeValuesBranched<T>(this object parent, params Type[] typesToSkip)
    {
        List<T> properties = new List<T>();

        foreach (MemberInfo member in parent.GetType().GetMembers())
        {
            Type type = member.GetTypeExt();
            if (type == typeof(T))
            {
                properties.Add((T)member.GetValue(parent));
            }
            else if (MemberCanBeBranched(member, parent))
            {
                if (typesToSkip.Contains(type) == false)
                {
                    List<Type> skip = typesToSkip.ToList();
                    skip.Add(type);
                    properties.AddRange(member.GetValue(parent).GetTypeValuesBranched<T>(skip.ToArray()));
                }
            }
        }

        return properties.ToArray();
    }

    /// <summary>
    /// Get all properties of type and branch to fields and their fields and etc.
    /// </summary>
    public static T[] GetTypeValuesBranched<T>(this object parent, BindingFlags bindingAttr, params Type[] typesToSkip)
    {
        List<T> properties = new List<T>();

        foreach (MemberInfo member in parent.GetType().GetMembers(bindingAttr))
        {
            Type type = member.GetTypeExt();
            if (type == typeof(T))
            {
                properties.Add((T)member.GetValue(parent));
            }
            else if (MemberCanBeBranched(member, parent))
            {
                if (typesToSkip.Contains(type) == false)
                {
                    List<Type> skip = typesToSkip.ToList();
                    skip.Add(type);
                    properties.AddRange(member.GetValue(parent).GetTypeValuesBranched<T>(bindingAttr, skip.ToArray()));
                }
            }
        }

        return properties.ToArray();
    }

    /// <summary>
    /// Get all properties of type and branch to fields and their fields and etc.
    /// </summary>
    public static T[] GetTypeValuesBranched<T>(this object parent, int branchTimes, params Type[] typesToSkip)
    {
        List<T> properties = new List<T>();

        foreach (MemberInfo member in parent.GetType().GetMembers())
        {
            Type type = member.GetTypeExt();
            if (type == typeof(T))
            {
                properties.Add((T)member.GetValue(parent));
            }
            else if (MemberCanBeBranched(member, parent) && branchTimes > 0)
            {
                if (typesToSkip.Contains(type) == false)
                {
                    List<Type> skip = typesToSkip.ToList();
                    skip.Add(type);
                    properties.AddRange(member.GetValue(parent).GetTypeValuesBranched<T>(branchTimes - 1, skip.ToArray()));
                }
            }
        }

        return properties.ToArray();
    }

    /// <summary>
    /// Get all properties of type and branch to fields and their fields and etc.
    /// </summary>
    public static T[] GetTypeValuesBranched<T>(this object parent, int branchTimes, BindingFlags bindingAttr, params Type[] typesToSkip)
    {
        List<T> properties = new List<T>();

        foreach (MemberInfo member in parent.GetType().GetMembers(bindingAttr))
        {
            Type type = member.GetTypeExt();
            if (type == typeof(T))
            {
                properties.Add((T)member.GetValue(parent));
            }
            else if (MemberCanBeBranched(member, parent) && branchTimes > 0)
            {
                if (typesToSkip.Contains(type) == false)
                {
                    List<Type> skip = typesToSkip.ToList();
                    skip.Add(type);
                    properties.AddRange(member.GetValue(parent).GetTypeValuesBranched<T>(branchTimes - 1, bindingAttr, skip.ToArray()));
                }
            }
        }

        return properties.ToArray();
    }

    /// <summary>
    /// Get all type values in fields and properties within a class.
    /// </summary>
    public static T[] GetTypeValuesByInheritance<T>(this object parent)
        where T : class
    {
        List<T> properties = new List<T>();

        foreach (MemberInfo member in parent.GetType().GetMembers())
        {
            if (typeof(T).IsAssignableFrom(member.GetTypeExt()))
            {
                properties.Add((T)member.GetValue(parent));
            }
        }

        return properties.ToArray();
    }

    /// <summary>
    /// Get all type values in fields and properties within a class.
    /// </summary>
    public static T[] GetTypeValuesByInheritance<T>(this object parent, BindingFlags bindingAttr)
        where T : class
    {
        List<T> properties = new List<T>();

        foreach (MemberInfo member in parent.GetType().GetMembers(bindingAttr))
        {
            if (typeof(T).IsAssignableFrom(member.GetTypeExt()))
            {
                properties.Add((T)member.GetValue(parent));
            }
        }

        return properties.ToArray();
    }

    /// <summary>
    /// Get all properties of type and branch to fields and their fields and etc.
    /// </summary>
    public static T[] GetTypeValuesByInheritanceBranched<T>(this object parent, params Type[] typesToSkip)
        where T : class
    {
        List<T> properties = new List<T>();

        foreach (MemberInfo member in parent.GetType().GetMembers())
        {
            Type type = member.GetTypeExt();
            if (typeof(T).IsAssignableFrom(type))
            {
                properties.Add((T)member.GetValue(parent));
            }
            else if (MemberCanBeBranched(member, parent))
            {
                if (typesToSkip.Contains(type) == false)
                {
                    List<Type> skip = typesToSkip.ToList();
                    skip.Add(type);
                    properties.AddRange(member.GetValue(parent).GetTypeValuesByInheritanceBranched<T>(skip.ToArray()));
                }
            }
        }

        return properties.ToArray();
    }

    /// <summary>
    /// Get all properties of type and branch to fields and their fields and etc.
    /// </summary>
    public static T[] GetTypeValuesByInheritanceBranched<T>(this object parent, BindingFlags bindingAttr, params Type[] typesToSkip)
        where T : class
    {
        List<T> properties = new List<T>();

        foreach (MemberInfo member in parent.GetType().GetMembers(bindingAttr))
        {
            Type type = member.GetTypeExt();
            if (typeof(T).IsAssignableFrom(type))
            {
                properties.Add((T)member.GetValue(parent));
            }
            else if (MemberCanBeBranched(member, parent))
            {
                if (typesToSkip.Contains(type) == false)
                {
                    List<Type> skip = typesToSkip.ToList();
                    skip.Add(type);
                    properties.AddRange(member.GetValue(parent).GetTypeValuesByInheritanceBranched<T>(bindingAttr, skip.ToArray()));
                }
            }
        }

        return properties.ToArray();
    }

    /// <summary>
    /// Get all properties of type and branch to fields and their fields and etc.
    /// </summary>
    public static T[] GetTypeValuesByInheritanceBranched<T>(this object parent, int branchTimes, params Type[] typesToSkip)
        where T : class
    {
        List<T> properties = new List<T>();

        foreach (MemberInfo member in parent.GetType().GetMembers())
        {
            Type type = member.GetTypeExt();
            if (typeof(T).IsAssignableFrom(type))
            {
                properties.Add((T)member.GetValue(parent));
            }
            else if (MemberCanBeBranched(member, parent) && branchTimes > 0)
            {
                if (typesToSkip.Contains(type) == false)
                {
                    List<Type> skip = typesToSkip.ToList();
                    skip.Add(type);
                    properties.AddRange(member.GetValue(parent).GetTypeValuesByInheritanceBranched<T>(branchTimes - 1, skip.ToArray()));
                }
            }
        }

        return properties.ToArray();
    }

    /// <summary>
    /// Get all properties of type and branch to fields and their fields and etc.
    /// </summary>
    public static T[] GetTypeValuesByInheritanceBranched<T>(this object parent, int branchTimes, BindingFlags bindingAttr, params Type[] typesToSkip)
        where T : class
    {
        List<T> properties = new List<T>();

        foreach (MemberInfo member in parent.GetType().GetMembers(bindingAttr))
        {
            Type type = member.GetTypeExt();
            if (typeof(T).IsAssignableFrom(type))
            {
                properties.Add((T)member.GetValue(parent));
            }
            else if (MemberCanBeBranched(member, parent) && branchTimes > 0)
            {
                if (typesToSkip.Contains(type) == false)
                {
                    List<Type> skip = typesToSkip.ToList();
                    skip.Add(type);
                    properties.AddRange(member.GetValue(parent).GetTypeValuesByInheritanceBranched<T>(branchTimes - 1, bindingAttr, skip.ToArray()));
                }
            }
        }

        return properties.ToArray();
    }

    private static bool MemberCanBeBranched(MemberInfo member, object parent)
    {
        try
        {
            Type type = member.GetTypeExt();

            return (type.IsGenericType == false
                && Attribute.IsDefined(type, typeof(ObsoleteAttribute)) == false
                && type != parent.GetType()
                && type.IsArray == false
                && type.IsClass
                && member.GetValue(parent) != null
                && type.IsSystemType() == false);
        }
        catch (Exception)
        {
            return false;
        }
    }
}
