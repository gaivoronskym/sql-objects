using System.Data;
using Dapper;
using SimpleSql.Interfaces;

namespace SimpleSql;

public class AsyncFetch : IAsyncFetch
{
    private readonly IDbConnection _connection;
    private readonly IQuery _query;
    private readonly int _timeout;

    public AsyncFetch(IDbConnection connection, IQuery query)
        : this(connection, query, 30)
    {
        
    }

    public AsyncFetch(IDbConnection connection, IQuery query, int timeout)
    {
        _connection = connection;
        _query = query;
        _timeout = timeout;
    }
    
    public async Task<IList<IRow>> Rows()
    {
        var res = await _connection.QueryAsync(
            sql: _query.Raw(),
            commandTimeout: _timeout
        );

        var list = res.Cast<IDictionary<string, object>>();

        IList<IRow> rows = new List<IRow>();
        foreach (var row in list)
        {
            rows.Add(new Row(row));
        }
        
        return rows;
    }
}