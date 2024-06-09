namespace SqlObjects.Interfaces;

public interface IAsyncExecution<T>
{
    Task<T> InvokeAsync();
}

public interface IAsyncExecution
{
    Task InvokeAsync();
}