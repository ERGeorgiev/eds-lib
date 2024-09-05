namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Task"/> type.
/// </summary>
public static partial class TaskExt
{
    /// <summary>
    /// </summary>
    /// <returns>A cancellation token source for the created task. It will be disposed by the task after it is cancelled.</returns>
    public static CancellationTokenSource NewPeriodicAction(Action action, TimeSpan frequency)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        Task.Run(
            () => NewPeriodicAction(action, frequency, cancellationTokenSource.Token)
            .ContinueWith((_) => cancellationTokenSource.Dispose())
        );
        Logger.LogDebug($"Started periodic action '{action.Method.Name}'");

        return cancellationTokenSource;
    }

    public static async Task NewPeriodicAction(Action action, TimeSpan frequency, CancellationToken cancellationToken)
    {
        var nextUpdate = DateTime.Now;
        try
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                nextUpdate = DateTime.Now + frequency; // Better than nextUpdate + freq, because nextUpdate + freq can accumulate lost time.
                action.Invoke();
                var timeUntilNextUpdate = nextUpdate - DateTime.Now;
                if (timeUntilNextUpdate.TotalMilliseconds < frequency.TotalMilliseconds / 2)
                    Logger.LogWarning($"Slow periodic action '{action.Method.Name}'" +
                        $" ({timeUntilNextUpdate.TotalMilliseconds}ms remaining / {frequency.TotalMilliseconds}ms total)");
                if (timeUntilNextUpdate.TotalMilliseconds > 0)
                    await Task.Delay(timeUntilNextUpdate);
            }
        }
        catch (Exception e)
        {
            Logger.LogError("Periodic task failed.", e);
            throw;
        }
    }
}
