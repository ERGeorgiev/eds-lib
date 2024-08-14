using System.Timers;

namespace EdsLibrary;

[Obsolete] // Unfinished
public class ActionTimer : IDisposable
{
    private ActionTimerElapsedEventHandler? onIntervalElapsed = null;
    private readonly CancellationTokenSource _disposeCancellation = new();

    public ActionTimer(TimeSpan duration, bool looping = false, TimeSpan? frequency = null)
    {
        Duration = duration;
        Looping = looping;
        Frequency = frequency;
        StartTime = DateTimeOffset.Now;
        EndTime = StartTime;
        Task.Run(MainLoop);
    }

    public TimeSpan Duration { get; set; }
    public bool Looping { get; set; }
    public TimeSpan? Frequency { get; set; }
    public DateTimeOffset StartTime { get; private set; } = DateTime.MinValue;
    public DateTimeOffset EndTime { get; private set; } = DateTime.MinValue;
    public bool Ended { get; private set; } = true;

    [TimersDescription("ActionTimerIntervalElapsed")]
    public event ActionTimerElapsedEventHandler OnElapsed
    {
        add
        {
            onIntervalElapsed = (ActionTimerElapsedEventHandler)Delegate.Combine(onIntervalElapsed, value);
        }
        remove
        {
            onIntervalElapsed = (ActionTimerElapsedEventHandler)Delegate.Remove(onIntervalElapsed, value);
        }
    }

    public void Start(TimeSpan? newDuration = null)
    {
        if (EndTime > StartTime) throw new InvalidOperationException("ActionTimer already started.");
        StartTime = DateTimeOffset.Now;
        if (newDuration != null) Duration = newDuration.Value;
        EndTime = StartTime + Duration;
        Ended = false;
    }

    public void Restart()
    {
        StartTime = DateTimeOffset.Now;
        EndTime = StartTime + Duration;
        Ended = false;
    }

    public void Dispose()
    {
        Ended = true;
        _disposeCancellation.Cancel();
    }

    private void MainLoop()
    {
        while (_disposeCancellation.IsCancellationRequested == false)
        {
            if (Frequency != null)
            {
                try
                {
                    Task.Delay(Duration, _disposeCancellation.Token).Wait();
                }
                catch (AggregateException e) when (e.InnerException is TaskCanceledException)
                {
                    return;
                }
            }

            if (Ended == false && EndTime >= StartTime && onIntervalElapsed != null)
            {
                Ended = true;
                Task.Run(onIntervalElapsed.Invoke); // ToDo: Will this invoke all added actions?
            }
        }
    }
}

public delegate void ActionTimerElapsedEventHandler();
