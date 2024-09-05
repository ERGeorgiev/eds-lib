namespace EdsLibrary.Extensions;

/// <summary>
/// Extensions for the <see cref="Task"/> type.
/// </summary>
public static partial class TaskExt
{
    /// <summary>
    /// </summary>
    /// <returns>A cancellation token source for the created task. It will be disposed by the task after it is cancelled.</returns>
    public static CancellationTokenSource NewPeriodic(string taskName, TimeSpan frequency, Action action)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        Task.Run(
            () => NewPeriodic(taskName, frequency, action, cancellationTokenSource.Token)
            .ContinueWith((_) => cancellationTokenSource.Dispose())
        );
        Logger.LogDebug($"Started a period task '{taskName}'");

        return cancellationTokenSource;
    }

    public static async Task NewPeriodic(string taskName, TimeSpan frequency, Action action, CancellationToken cancellationToken)
    {
        var nextUpdate = DateTime.Now;
        while (cancellationToken.IsCancellationRequested == false)
        {
            nextUpdate = DateTime.Now + frequency; // Better than nextUpdate + freq, because nextUpdate + freq can accumulate lost time.
            action.Invoke();
            var timeUntilNextUpdate = nextUpdate - DateTime.Now;
            if (timeUntilNextUpdate.TotalMilliseconds < frequency.TotalMilliseconds / 2)
                Logger.LogWarning($"Slow update for task '{taskName}' ({timeUntilNextUpdate.TotalMilliseconds}ms remaining / {frequency.TotalMilliseconds}ms total)");
            if (timeUntilNextUpdate.TotalMilliseconds > 0)
                await Task.Delay(timeUntilNextUpdate);
        }
    }
}
