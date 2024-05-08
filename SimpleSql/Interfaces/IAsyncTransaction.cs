namespace SimpleSql.Interfaces;

public interface IAsyncTransaction
{
    Task Invoke();
}