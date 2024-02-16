using System;
using System.Collections;
using System.Collections.Generic;

namespace EdsLibrary.Extensions
{
    /// <summary>
    /// Extension to the System.Random class.
    /// </summary>
    public static partial class RandomExt
    {
        public static Random Random = new Random();

        /// <summary>
        /// Returns a random element.
        /// </summary>
        public static T RandomElement<T>(this T[] elements)
        {
            return elements[Random.Next(elements.Length)];
        }

        /// <summary>
        /// Returns a random element.
        /// </summary>
        public static T RandomElement<T>(this IList<T> elements)
        {
            return elements[Random.Next(elements.Count)];
        }

        /// <summary>
        /// Generates a sign (e.g. -1 or 1).
        /// </summary>
        public static int Sign(this Random random)
        {
            return (random.NextDouble() >= 0.5f) ? 1 : -1;
        }

        /// <summary>
        /// Generates a sign (e.g. -1 or 1).
        /// </summary>
        public static int Sign()
        {
            return (Random.NextDouble() >= 0.5f) ? 1 : -1;
        }
    }
}