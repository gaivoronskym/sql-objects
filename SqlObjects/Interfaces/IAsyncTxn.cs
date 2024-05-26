namespace SqlObjects.Interfaces;

public interface IAsyncTxn<T>
{
    Task<T> Invoke();
}