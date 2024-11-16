namespace SqlObjects.Interfaces;

public interface IAsyncFetch
{
    Task<IList<IRow>> RowsAsync(IQuery query);
}