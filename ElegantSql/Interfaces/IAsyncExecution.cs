namespace ElegantSql.Interfaces;

public interface IAsyncExecution<T>
{
    Task<T> InvokeAsync();
}