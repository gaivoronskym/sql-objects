namespace SqlObjects.Interfaces;

public interface IAsyncTxn<T>
{
    Task<T> Invoke(Func<Task<T>> func);
}