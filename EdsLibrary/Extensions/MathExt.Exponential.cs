using System;

namespace EdsLibrary.Extensions
{
    /// <summary>
    /// Extension to the System.Math class.
    /// </summary>
    public static partial class MathExt
    {
        /// <summary>
        /// Converts value into an exponential one.
        /// Example: 0 would be 0, 0.5 would be ~0.4, 1 would be 1.
        /// </summary>
        /// <param name="value">Between 0 and 1.</param>
        /// <returns>Exponential value.</returns>
        public static double Exponential(sbyte value, int exponent = 2)
        {
            return (Math.Pow(exponent, value) - 1) / (exponent - 1);
        }

        /// <summary>
        /// Converts value into an exponential one.
        /// Example: 0 would be 0, 0.5 would be ~0.4, 1 would be 1.
        /// </summary>
        /// <param name="value">Between 0 and 1.</param>
        /// <returns>Exponential value.</returns>
        public static double Exponential(byte value, int exponent = 2)
        {
            return (Math.Pow(exponent, value) - 1) / (exponent - 1);
        }

        /// <summary>
        /// Converts value into an exponential one.
        /// Example: 0 would be 0, 0.5 would be ~0.4, 1 would be 1.
        /// </summary>
        /// <param name="value">Between 0 and 1.</param>
        /// <returns>Exponential value.</returns>
        public static double Exponential(ushort value, int exponent = 2)
        {
            return (Math.Pow(exponent, value) - 1) / (exponent - 1);
        }

        /// <summary>
        /// Converts value into an exponential one.
        /// Example: 0 would be 0, 0.5 would be ~0.4, 1 would be 1.
        /// </summary>
        /// <param name="value">Between 0 and 1.</param>
        /// <returns>Exponential value.</returns>
        public static double Exponential(short value, int exponent = 2)
        {
            return (Math.Pow(exponent, value) - 1) / (exponent - 1);
        }

        /// <summary>
        /// Converts value into an exponential one.
        /// Example: 0 would be 0, 0.5 would be ~0.4, 1 would be 1.
        /// </summary>
        /// <param name="value">Between 0 and 1.</param>
        /// <returns>Exponential value.</returns>
        public static double Exponential(uint value, int exponent = 2)
        {
            return (Math.Pow(exponent, value) - 1) / (exponent - 1);
        }

        /// <summary>
        /// Converts value into an exponential one.
        /// Example: 0 would be 0, 0.5 would be ~0.4, 1 would be 1.
        /// </summary>
        /// <param name="value">Between 0 and 1.</param>
        /// <returns>Exponential value.</returns>
        public static double Exponential(int value, int exponent = 2)
        {
            return (Math.Pow(exponent, value) - 1) / (exponent - 1);
        }

        /// <summary>
        /// Converts value into an exponential one.
        /// Example: 0 would be 0, 0.5 would be ~0.4, 1 would be 1.
        /// </summary>
        /// <param name="value">Between 0 and 1.</param>
        /// <returns>Exponential value.</returns>
        public static double Exponential(ulong value, int exponent = 2)
        {
            return (Math.Pow(exponent, value) - 1) / (exponent - 1);
        }

        /// <summary>
        /// Converts value into an exponential one.
        /// Example: 0 would be 0, 0.5 would be ~0.4, 1 would be 1.
        /// </summary>
        /// <param name="value">Between 0 and 1.</param>
        /// <returns>Exponential value.</returns>
        public static double Exponential(long value, int exponent = 2)
        {
            return (Math.Pow(exponent, value) - 1) / (exponent - 1);
        }

        /// <summary>
        /// Converts value into an exponential one.
        /// Example: 0 would be 0, 0.5 would be ~0.4, 1 would be 1.
        /// </summary>
        /// <param name="value">Between 0 and 1.</param>
        /// <returns>Exponential value.</returns>
        public static float Exponential(float value, int exponent = 2)
        {
            return (float)(Math.Pow(exponent, value) - 1) / (exponent - 1);
        }

        /// <summary>
        /// Converts value into an exponential one.
        /// Example: 0 would be 0, 0.5 would be ~0.4, 1 would be 1.
        /// </summary>
        /// <param name="value">Between 0 and 1.</param>
        /// <returns>Exponential value.</returns>
        public static double Exponential(double value, int exponent = 2)
        {
            return (Math.Pow(exponent, value) - 1) / (exponent - 1);
        }

        /// <summary>
        /// Converts value into an exponential one.
        /// Example: 0 would be 0, 0.5 would be ~0.4, 1 would be 1.
        /// </summary>
        /// <param name="value">Between 0 and 1.</param>
        /// <returns>Exponential value.</returns>
        public static decimal Exponential(decimal value, int exponent = 2)
        {
            return (decimal)(Math.Pow(exponent, (double)value) - 1) / (exponent - 1);
        }
    }
}