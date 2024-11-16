namespace SqlObjects.Interfaces;

public interface IAsyncStatement
{
    Task<T> ExecAsync<T>(IQuery query);

    Task ExecAsync(IQuery query);
}