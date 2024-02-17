using System.Security.Principal;

namespace EdsLibrary.Extensions;

public static partial class IPrincipalExt
{
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
