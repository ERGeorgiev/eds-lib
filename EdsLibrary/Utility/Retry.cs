using EdsLibrary.ConsoleHelpers;

namespace EdsLibrary;

public static class Retry
{
    /// <summary>
    /// Retries the given operation several times with a delay in-between each try.
    /// </summary>
    /// <param name="operation">The operation to execute.</param>
    /// <param name="times">Times to retry on fail.</param>
    /// <param name="delay">Delay between retries. Leave null to default to 5 seconds.</param>
    public static void OnException(Action operation, int times = 3, TimeSpan? delay = null)
    {
        OnExceptionAsync(operation, times, delay).Wait();
    }

    /// <summary>
    /// Retries the given operation several times with a delay in-between each try.
    /// </summary>
    /// <param name="operation">The operation to execute.</param>
    /// <param name="times">Times to retry on fail.</param>
    /// <param name="delay">Delay between retries. Leave null to default to 5 seconds.</param>
    public static async Task OnExceptionAsync(Action operation, int times = 3, TimeSpan? delay = null)
    {
        TimeSpan delayTime = delay ?? TimeSpan.FromSeconds(5);

        var attempts = 0;
        do
        {
            try
            {
                attempts++;
                operation();
                break;
            }
            catch (Exception e)
            {
                if (attempts == times)
                    throw;

                // ToDo: Should use logger
                ConsoleMenu.LogException(e);
                Console.WriteLine($"Attempt {attempts}/{times}. Retry after delay {delayTime}");

                await Task.Delay(delayTime);
            }
        } while (true);
    }

    /// <summary>
    /// Retries the given operation several times with a delay in-between each try.
    /// </summary>
    /// <param name="operation">The operation to execute.</param>
    /// <param name="times">Times to retry on fail.</param>
    /// <param name="delay">Delay between retries. Leave null to default to 5 seconds.</param>
    public static async Task<T> OnExceptionAsync<T>(Task<T> operation, int times = 3, TimeSpan? delay = null)
    {
        TimeSpan delayTime = delay ?? TimeSpan.FromSeconds(5);

        var attempts = 0;
        do
        {
            try
            {
                attempts++;
                var result = await operation;
                return result;
            }
            catch (Exception e)
            {
                if (attempts == times)
                    throw;

                // ToDo: Should use logger
                ConsoleMenu.LogException(e);
                Console.WriteLine($"Attempt {attempts}/{times}. Retry after delay {delayTime}");

                await Task.Delay(delayTime);
            }
        } while (true);
    }
}
