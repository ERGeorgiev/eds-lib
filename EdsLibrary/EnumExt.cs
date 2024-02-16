using EdsLibrary.Extensions;

namespace EdsLibrary;

public static partial class EnumExt
{
    public static T Random<T>() where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("Enum must be an enumerated type");
        }
        Array enums = Enum.GetValues(typeof(T));
        return (T)enums.GetValue(RandomExt.Shared.Next(enums.Length));
    }
}
