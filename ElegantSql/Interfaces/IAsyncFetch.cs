namespace ElegantSql.Interfaces;

public interface IAsyncFetch
{
    Task<IList<IRow>> RowsAsync();
}