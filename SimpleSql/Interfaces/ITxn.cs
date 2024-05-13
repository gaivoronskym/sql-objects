namespace SimpleSql.Interfaces;

public interface ITxn
{
    /// <summary>
    /// Runs SQL queries in transaction
    /// </summary>
    void Invoke();
}