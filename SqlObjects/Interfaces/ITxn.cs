namespace SqlObjects.Interfaces;

public interface ITxn<T>
{
    /// <summary>
    /// Runs SQL queries in transaction
    /// </summary>
    T Invoke();
}