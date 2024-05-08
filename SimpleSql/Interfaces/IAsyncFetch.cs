namespace SimpleSql.Interfaces;

public interface IAsyncFetch
{
    Task<IList<IRow>> Rows();
}