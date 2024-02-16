using System;

namespace EdsLibrary.Extensions;

/// <summary>
/// Extension to the System.Random class.
/// </summary>
public static partial class RandomExt
{
    /// <summary>
    /// Generates a random integer variable.
    /// UNSAFE FOR MULTITHREADING.
    /// </summary>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Exclusive upper limit.</param>
    /// <returns>Random value within the given range.</returns>
    public static int Next(int min, int max)
    {
        return Shared.Next(min, max);
    }

    /// <summary>
    /// Generates a random float variable.
    /// UNSAFE FOR MULTITHREADING.
    /// </summary>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Exclusive upper limit.</param>
    /// <returns>Random value within the given range.</returns>
    public static float Next(float min, float max)
    {
        return (float)((Shared.NextDouble() * (max - min)) + min);
    }

    /// <summary>
    /// Generates a random float variable.
    /// </summary>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Exclusive upper limit.</param>
    /// <returns>Random value within the given range.</returns>
    public static float Next(this Random random, float min, float max)
    {
        return (float)((random.NextDouble() * (max - min)) + min);
    }

    /// <summary>
    /// Generates a random double variable.
    /// UNSAFE FOR MULTITHREADING.
    /// </summary>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Inclusive upper limit.</param>
    /// <returns>Random value within the given range.</returns>
    public static double Next(double min, double max)
    {
        return (Shared.NextDouble() * (max - min)) + min;
    }

    /// <summary>
    /// Generates a random float variable.
    /// </summary>
    /// <param name="min">Inclusive lower limit.</param>
    /// <param name="max">Exclusive upper limit.</param>
    /// <returns>Random value within the given range.</returns>
    public static double Next(this Random random, double min, double max)
    {
        return (random.NextDouble() * (max - min)) + min;
    }

    /// <summary>
    /// Generates a random float variable from 0 to 1.
    /// UNSAFE FOR MULTITHREADING.
    /// </summary>
    /// <returns>Float from 0 to 1.</returns>
    public static float Next()
    {
        return (float)Shared.NextDouble();
    }
}
