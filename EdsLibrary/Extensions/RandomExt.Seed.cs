namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Random"/> type.
/// </summary>
public static partial class RandomExt
{
    /// <summary>
    /// Uses a seed to produce predictable results.
    /// </summary>
    /// <param name="seed">Will be turned into a numerical seed.</param>
    public static void Seed(string seed, int maxLength = 32)
    {
        int numericSeed = 0;
        for (int i = 0; i < seed.Length && i < maxLength; i++)
        {
            numericSeed += seed[i] * (i + 1);
        }

        Shared = new Random(numericSeed);
    }

    /// <summary>
    /// Uses a seed to produce predictable results.
    /// </summary>
    public static void Seed(int seed)
    {
        Shared = new Random(seed);
    }
}
