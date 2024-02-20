namespace EdsLibrary.Threading;

public interface ITaskRunner
{
    void Clear();
    void Enqueue(Task task);
}
