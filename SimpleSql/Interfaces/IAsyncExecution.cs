namespace SimpleSql.Interfaces;

public interface IAsyncExecution<T>
{
    Task<T> InvokeAsync();
}