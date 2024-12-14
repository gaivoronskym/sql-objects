namespace SqlObjects.Interfaces;

public interface ITxn
{
    /// <summary>
    /// Runs SQL queries in transaction
    /// </summary>
    T Invoke<T>(Func<T> func);

    Task<T> Invoke<T>(Func<Task<T>> func);

    void Begin();

    void Commit();

    void Rollback();
}