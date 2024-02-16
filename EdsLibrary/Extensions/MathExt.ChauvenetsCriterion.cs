namespace EdsLibrary.Extensions;

/// <summary>
/// Extension to the System.Math class.
/// </summary>
public static partial class MathExt
    {
        /// <summary>
        /// Removes sample outliers using Chauvenet's Criterion.
        /// </summary>
        /// <param name="values">Input numbers.</param>
        /// <returns>A collection similar to the input one, but without the outliers.</returns>
        /// <remarks>More info: https://en.wikipedia.org/wiki/Chauvenet%27s_criterion </remarks>
        public static IEnumerable<int> ChauvenetsCriterion(IEnumerable<int> values, double maxDeviation)
        {
            List<int> output = new List<int>();
            double avg = values.Average();
            double stdev = StandardDeviation(values);

            foreach (var item in values)
            {
                double deviation = Math.Abs(item - avg) / stdev;
                if (maxDeviation >= deviation)
                {
                    output.Add(item);
                }
            }

            return output;
        }

        /// <summary>
        /// Removes sample outliers using Chauvenet's Criterion.
        /// </summary>
        /// <param name="values">Input numbers.</param>
        /// <returns>A collection similar to the input one, but without the outliers.</returns>
        /// <remarks>More info: https://en.wikipedia.org/wiki/Chauvenet%27s_criterion </remarks>
        public static IEnumerable<long> ChauvenetsCriterion(IEnumerable<long> values, float maxDeviation)
        {
            List<long> output = new List<long>();
            double avg = values.Average();
            double stdev = StandardDeviation(values);

            foreach (var item in values)
            {
                double deviation = Math.Abs(item - avg) / stdev;
                if (maxDeviation >= deviation)
                {
                    output.Add(item);
                }
            }

            return output;
        }

        /// <summary>
        /// Removes sample outliers using Chauvenet's Criterion.
        /// </summary>
        /// <param name="values">Input numbers.</param>
        /// <returns>A collection similar to the input one, but without the outliers.</returns>
        /// <remarks>More info: https://en.wikipedia.org/wiki/Chauvenet%27s_criterion </remarks>
        public static IEnumerable<float> ChauvenetsCriterion(IEnumerable<float> values, float maxDeviation)
        {
            List<float> output = new List<float>();
            double avg = values.Average();
            double stdev = StandardDeviation(values);

            foreach (var item in values)
            {
                double deviation = Math.Abs(item - avg) / stdev;
                if (maxDeviation >= deviation)
                {
                    output.Add(item);
                }
            }

            return output;
        }

        /// <summary>
        /// Removes sample outliers using Chauvenet's Criterion.
        /// </summary>
        /// <param name="values">Input numbers.</param>
        /// <returns>A collection similar to the input one, but without the outliers.</returns>
        /// <remarks>More info: https://en.wikipedia.org/wiki/Chauvenet%27s_criterion </remarks>
        public static IEnumerable<double> ChauvenetsCriterion(IEnumerable<double> values, float maxDeviation)
        {
            List<double> output = new List<double>();
            double avg = values.Average();
            double stdev = StandardDeviation(values);

            foreach (var item in values)
            {
                double deviation = Math.Abs(item - avg) / stdev;
                if (maxDeviation >= deviation)
                {
                    output.Add(item);
                }
            }

            return output;
        }
    }
