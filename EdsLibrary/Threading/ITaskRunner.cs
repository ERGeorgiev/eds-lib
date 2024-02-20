namespace EdsWindowsMods.Core.Framework;

public interface ITaskRunner
{
    void Clear();
    void Enqueue(Task task);
}
