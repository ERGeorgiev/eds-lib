using System.Reflection;
using System.Security.Principal;

namespace EdsLibrary;

public static partial class PropertyInfoExt
{
    public static object GetId(this PropertyInfo property, object source)
    {
        var idProperties = property.PropertyType.GetProperties();
        var idProperty = idProperties
            .FirstOrDefault(p => string.Equals(p.Name, "id", StringComparison.OrdinalIgnoreCase));
        return idProperty?.GetValue(property.GetValue(source));
    }

    public static bool IsInRole(this IPrincipal user, IEnumerable<string> roles)
    {
        foreach (var role in roles)
        {
            if (user.IsInRole(role))
            {
                return true;
            }
        }
        return false;
    }
}
