using System;
using System.Collections.Generic;
using System.Linq;

namespace EdsLibrary.Extensions
{
    /// <summary>
    /// Extension to the System.Math class.
    /// </summary>
    public static partial class MathExt
    {
        /// <summary>
        /// Calculates the standard deviation of a set of values.
        /// </summary>
        /// <param name="values">Input numbers.</param>
        /// <returns>Standard deviation of the input.</returns>
        public static double StandardDeviation(IEnumerable<int> values)
        {
            if (values.Any() == false) return 0;

            double avg = values.Average();
            return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }

        /// <summary>
        /// Calculates the standard deviation of a set of values.
        /// </summary>
        /// <param name="values">Input numbers.</param>
        /// <returns>Standard deviation of the input.</returns>
        public static double StandardDeviation(IEnumerable<long> values)
        {
            if (values.Any() == false) return 0;

            double avg = values.Average();
            return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }

        /// <summary>
        /// Calculates the standard deviation of a set of values.
        /// </summary>
        /// <param name="values">Input numbers.</param>
        /// <returns>Standard deviation of the input.</returns>
        public static double StandardDeviation(IEnumerable<float> values)
        {
            if (values.Any() == false) return 0;

            double avg = values.Average();
            return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }

        /// <summary>
        /// Calculates the standard deviation of a set of values.
        /// </summary>
        /// <param name="values">Input numbers.</param>
        /// <returns>Standard deviation of the input.</returns>
        public static double StandardDeviation(IEnumerable<double> values)
        {
            if (values.Any() == false) return 0;

            double avg = values.Average();
            return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }
    }
}