using System.Reflection;

namespace EdsLibrary.Extensions;

public static partial class PropertyInfoExt
{
    public static object? GetId(this PropertyInfo property, object source)
    {
        var idProperties = property.PropertyType.GetProperties();
        var idProperty = idProperties
            .FirstOrDefault(p => string.Equals(p.Name, "id", StringComparison.OrdinalIgnoreCase));
        return idProperty?.GetValue(property.GetValue(source));
    }
}
