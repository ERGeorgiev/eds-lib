using System;

namespace EdsLibrary.Extensions
{
    /// <summary>
    /// Extension to the System.Math class.
    /// </summary>
    public static partial class MathExt
    {
        /// <summary>
        /// Constricts the value within [-limit, limit].
        /// </summary>
        public static sbyte LimitAbs(this sbyte value, sbyte limit)
        {
            limit = Math.Abs(limit);
            if (value >= 0) return value.Limit(0, limit);
            return value.Limit((sbyte)-limit, 0);
        }

        /// <summary>
        /// Constricts the value within [-limit, limit].
        /// </summary>
        public static short LimitAbs(this short value, short limit)
        {
            limit = Math.Abs(limit);
            if (value >= 0) return value.Limit(0, limit);
            return value.Limit((short)-limit, 0);
        }

        /// <summary>
        /// Constricts the value within [-limit, limit].
        /// </summary>
        public static int LimitAbs(this int value, int limit)
        {
            limit = Math.Abs(limit);
            if (value >= 0) return value.Limit(0, limit);
            return value.Limit(-limit, 0);
        }

        /// <summary>
        /// Constricts the value within [-limit, limit].
        /// </summary>
        public static long LimitAbs(this long value, long limit)
        {
            limit = Math.Abs(limit);
            if (value >= 0) return value.Limit(0, limit);
            return value.Limit(-limit, 0);
        }

        /// <summary>
        /// Constricts the value within [-limit, limit].
        /// </summary>
        public static float LimitAbs(this float value, float limit)
        {
            limit = Math.Abs(limit);
            if (value >= 0) return value.Limit(0, limit);
            return value.Limit(-limit, 0);
        }
        /// <summary>
        /// Constricts the value within [-limit, limit].
        /// </summary>

        public static double LimitAbs(this double value, double limit)
        {
            limit = Math.Abs(limit);
            if (value >= 0) return value.Limit(0, limit);
            return value.Limit(-limit, 0);
        }

        /// <summary>
        /// Constricts the value within [-limit, limit].
        /// </summary>
        public static decimal LimitAbs(this decimal value, decimal limit)
        {
            limit = Math.Abs(limit);
            if (value >= 0) return value.Limit(0, limit);
            return value.Limit(-limit, 0);
        }
    }
}