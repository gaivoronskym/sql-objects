namespace SimpleSql.Interfaces;

public interface ISyncExecution<T>
{
    T Invoke();
}