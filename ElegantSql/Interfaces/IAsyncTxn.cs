namespace ElegantSql.Interfaces;

public interface IAsyncTxn
{
    Task Invoke();
}