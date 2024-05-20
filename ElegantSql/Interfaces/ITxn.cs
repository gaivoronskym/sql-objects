namespace ElegantSql.Interfaces;

public interface ITxn
{
    /// <summary>
    /// Runs SQL queries in transaction
    /// </summary>
    void Invoke();
}