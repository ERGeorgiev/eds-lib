using System;

namespace EdsLibrary.Extensions
{
    /// <summary>
    /// Extension to the System.Random class.
    /// </summary>
    public static partial class RandomExt
    {
        private const int stringSeedMaxLength = 32;

        /// <summary>
        /// Uses a seed to produce predictable results.
        /// </summary>
        /// <param name="seed">Will be turned into a numerical seed.</param>
        public static void Seed(string seed)
        {
            seed.Truncate(stringSeedMaxLength);
            char[] seedCharacters = seed.ToCharArray();
            int numericSeed = 0;

            for (int i = 0; i < seedCharacters.Length; i++)
            {
                numericSeed += (int)char.GetNumericValue(seedCharacters[i]) * (i + 1);
            }

            Seed(numericSeed);
        }

        /// <summary>
        /// Uses a seed to produce predictable results.
        /// </summary>
        /// <param name="seed">Will be turned into a numerical seed.</param>
        public static void Seed(this Random random, string seed)
        {
            seed.Truncate(stringSeedMaxLength);
            char[] seedCharacters = seed.ToCharArray();
            int numericSeed = 0;

            for (int i = 0; i < seedCharacters.Length; i++)
            {
                numericSeed += (int)char.GetNumericValue(seedCharacters[i]) * (i + 1);
            }

            Random = new Random(numericSeed);
        }

        /// <summary>
        /// Uses a seed to produce predictable results.
        /// </summary>
        public static void Seed(int seed)
        {
            Random = new Random(seed);
        }

        /// <summary>
        /// Uses a seed to produce predictable results.
        /// </summary>
        public static void Seed(this Random random, int seed)
        {
            random = new Random(seed);
        }
    }
}