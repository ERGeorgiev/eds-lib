namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Math"/> type.
/// </summary>
public static partial class MathExt
{

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double Normalize(this sbyte value, float currentMinimum, float currentMaximum, float newMinumum = 0, float newMaximum = 1)
    {
        return (newMaximum - newMinumum) / (currentMaximum - currentMinimum) * (value - currentMaximum) + newMaximum;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double Normalize(this byte value, float currentMinimum, float currentMaximum, float newMinumum = 0, float newMaximum = 1)
    {
        return (newMaximum - newMinumum) / (currentMaximum - currentMinimum) * (value - currentMaximum) + newMaximum;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double Normalize(this ushort value, float currentMinimum, float currentMaximum, float newMinumum = 0, float newMaximum = 1)
    {
        return (newMaximum - newMinumum) / (currentMaximum - currentMinimum) * (value - currentMaximum) + newMaximum;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double Normalize(this short value, float currentMinimum, float currentMaximum, float newMinumum = 0, float newMaximum = 1)
    {
        return (newMaximum - newMinumum) / (currentMaximum - currentMinimum) * (value - currentMaximum) + newMaximum;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double Normalize(this uint value, float currentMinimum, float currentMaximum, float newMinumum = 0, float newMaximum = 1)
    {
        return (newMaximum - newMinumum) / (currentMaximum - currentMinimum) * (value - currentMaximum) + newMaximum;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double Normalize(this int value, float currentMinimum, float currentMaximum, float newMinumum = 0, float newMaximum = 1)
    {
        return (newMaximum - newMinumum) / (currentMaximum - currentMinimum) * (value - currentMaximum) + newMaximum;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double Normalize(this long value, float currentMinimum, float currentMaximum, float newMinumum = 0, float newMaximum = 1)
    {
        return (newMaximum - newMinumum) / (currentMaximum - currentMinimum) * (value - currentMaximum) + newMaximum;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double Normalize(this ulong value, float currentMinimum, float currentMaximum, float newMinumum = 0, float newMaximum = 1)
    {
        return (newMaximum - newMinumum) / (currentMaximum - currentMinimum) * (value - currentMaximum) + newMaximum;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static float Normalize(this float value, float currentMinimum, float currentMaximum, float newMinumum = 0, float newMaximum = 1)
    {
        return (newMaximum - newMinumum) / (currentMaximum - currentMinimum) * (value - currentMaximum) + newMaximum;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double Normalize(this double value, double currentMinimum, double currentMaximum, double newMinumum = 0, double newMaximum = 1)
    {
        return (newMaximum - newMinumum) / (currentMaximum - currentMinimum) * (value - currentMaximum) + newMaximum;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static decimal Normalize(this decimal value, decimal currentMinimum, decimal currentMaximum, decimal newMinumum = 0, decimal newMaximum = 1)
    {
        return (newMaximum - newMinumum) / (currentMaximum - currentMinimum) * (value - currentMaximum) + newMaximum;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double[] Normalize(this sbyte[] values, double minimum, double maximum, double newMinumum = 0, double newMaximum = 1)
    {
        double[] results = new double[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = (newMaximum - newMinumum) / (maximum - minimum) * (values[i] - maximum) + newMaximum;
        }

        return results;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double[] Normalize(this byte[] values, double minimum, double maximum, double newMinumum = 0, double newMaximum = 1)
    {
        double[] results = new double[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = (newMaximum - newMinumum) / (maximum - minimum) * (values[i] - maximum) + newMaximum;
        }

        return results;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double[] Normalize(this ushort[] values, double minimum, double maximum, double newMinumum = 0, double newMaximum = 1)
    {
        double[] results = new double[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = (newMaximum - newMinumum) / (maximum - minimum) * (values[i] - maximum) + newMaximum;
        }

        return results;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double[] Normalize(this short[] values, double minimum, double maximum, double newMinumum = 0, double newMaximum = 1)
    {
        double[] results = new double[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = (newMaximum - newMinumum) / (maximum - minimum) * (values[i] - maximum) + newMaximum;
        }

        return results;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double[] Normalize(this uint[] values, double minimum, double maximum, double newMinumum = 0, double newMaximum = 1)
    {
        double[] results = new double[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = (newMaximum - newMinumum) / (maximum - minimum) * (values[i] - maximum) + newMaximum;
        }

        return results;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double[] Normalize(this int[] values, double minimum, double maximum, double newMinumum = 0, double newMaximum = 1)
    {
        double[] results = new double[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = (newMaximum - newMinumum) / (maximum - minimum) * (values[i] - maximum) + newMaximum;
        }

        return results;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double[] Normalize(this ulong[] values, double minimum, double maximum, double newMinumum = 0, double newMaximum = 1)
    {
        double[] results = new double[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = (newMaximum - newMinumum) / (maximum - minimum) * (values[i] - maximum) + newMaximum;
        }

        return results;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double[] Normalize(this long[] values, double minimum, double maximum, double newMinumum = 0, double newMaximum = 1)
    {
        double[] results = new double[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = (newMaximum - newMinumum) / (maximum - minimum) * (values[i] - maximum) + newMaximum;
        }

        return results;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static float[] Normalize(this float[] values, float minimum, float maximum, float newMinumum = 0, float newMaximum = 1)
    {
        float[] results = new float[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = (newMaximum - newMinumum) / (maximum - minimum) * (values[i] - maximum) + newMaximum;
        }

        return results;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static double[] Normalize(this double[] values, double minimum, double maximum, double newMinumum = 0, double newMaximum = 1)
    {
        double[] results = new double[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = (newMaximum - newMinumum) / (maximum - minimum) * (values[i] - maximum) + newMaximum;
        }

        return results;
    }

    /// <summary>
    /// Normalizes a value within the given range.
    /// </summary>
    /// <param name="value">Value to normalize.</param>
    /// <param name="currentMinimum">Inclusive.</param>
    /// <param name="currentMaximum">Inclusive.</param>
    /// <param name="newMinumum">Default is 0.</param>
    /// <param name="newMaximum">Default is 1.</param>
    public static decimal[] Normalize(this decimal[] values, decimal minimum, decimal maximum, decimal newMinumum = 0, decimal newMaximum = 1)
    {
        decimal[] results = new decimal[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = (newMaximum - newMinumum) / (maximum - minimum) * (values[i] - maximum) + newMaximum;
        }

        return results;
    }
}
