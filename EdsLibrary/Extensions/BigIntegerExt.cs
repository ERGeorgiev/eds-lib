using System.Numerics;

namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="BigInteger"/> type.
/// </summary>
public static partial class BigIntegerExt
{
    /// <summary>
    /// Multiplies a BigInteger. For accuracy, only use multiplier [1E-7;1E7]. The result is truncated.
    /// </summary>
    /// <param name="multiplier">For accuracy, only use multiplier [1E-7;1E7].</param>
    /// <returns>The result is truncated.</returns>
    public static BigInteger Multiply(this BigInteger value, float multiplier)
    {
        return (value * new BigInteger(10000000d * multiplier)) / 10000000;
    }
}
