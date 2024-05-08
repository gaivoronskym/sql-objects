namespace SimpleSql.Interfaces;

public interface IExecution<T>
{
    T Invoke();
}