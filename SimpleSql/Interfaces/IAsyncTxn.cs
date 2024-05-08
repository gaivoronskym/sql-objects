namespace SimpleSql.Interfaces;

public interface IAsyncTxn
{
    Task Invoke();
}