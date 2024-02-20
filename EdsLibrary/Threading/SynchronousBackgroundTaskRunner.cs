namespace EdsWindowsMods.Core.Framework;

/// <summary>
/// Errors will go unnoticed as they fail within a headless task, make sure to use error handling withing the tasks.
/// </summary>
public class SynchronousBackgroundTaskRunner : ITaskRunner
{
    private readonly Queue<Task> _queue = new();
    private Task? _currentTask = null;
    private readonly object _lock = new();
    private readonly int _delayBetweenTasksMs = new();

    public SynchronousBackgroundTaskRunner(int msDelayBetweenTasks = 0)
    {
        _delayBetweenTasksMs = msDelayBetweenTasks;
    }

    public Action? OnAllTasksCompleted { get; set; }
    public int Capacity { get; set; } = 3;

    public void Clear()
    {
        lock (_lock)
        {
            _queue.Clear();
        }
    }

    public Task EnqueueAsync(Action action) => Task.Run(() => Enqueue(action));

    public Task EnqueueAsync(Task task) => Task.Run(() => Enqueue(task));

    public void Enqueue(Action action) => Enqueue(new Task(action));

    public void Enqueue(Task task)
    {
        if (_queue.Count >= Capacity)
        {
            Logger.LogWarning(() => $"Task queue has reached maximum capacity, rejecting task.");
            return;
        }

        lock (_lock)
        {
            if (_currentTask == null)
            {
                Logger.LogTrace(() => $"Running task as current.");
                RunAsCurrent(task);
            }
            else
            {
                Logger.LogTrace(() => $"Enqueuing task.");
                _queue.Enqueue(task);
            }
        }
    }

    private void RunAsCurrent(Task task)
    {
        lock (_lock)
        {
            _currentTask = task;
            task.ContinueWith(t => OnCompletion());
            task.Start();
        }
    }

    private void OnCompletion()
    {
        Logger.LogTrace(() => $"Task completed.");
        lock (_lock)
        {
            if (_queue.Count > 0)
            {
                Logger.LogTrace(() => $"Running next task.");
                if (_delayBetweenTasksMs > 0) Task.Delay(_delayBetweenTasksMs).Wait();
                RunAsCurrent(_queue.Dequeue());
            }
            else
            {
                Logger.LogTrace(() => "All tasks completed.");
                if (OnAllTasksCompleted != null)
                {
                    Logger.LogTrace(() => $"Running OnAllTasksCompleted task");
                    OnAllTasksCompleted.Invoke();
                    Logger.LogTrace(() => $"Finished OnAllTasksCompleted task");
                }
                _currentTask = null;
            }
        }
    }
}
