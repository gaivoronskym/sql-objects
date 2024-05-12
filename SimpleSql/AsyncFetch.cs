using System.Data;
using Dapper;
using SimpleSql.Interfaces;

namespace SimpleSql;

public sealed class AsyncFetch(IDbConnection connection, IQuery query, int timeout) : IAsyncFetch
{
    public AsyncFetch(IDbConnection connection, IQuery query)
        : this(connection, query, 30)
    {
        
    }

    public async Task<IList<IRow>> RowsAsync()
    {
        var res = await connection.QueryAsync(
            sql: query.Raw(),
            commandTimeout: timeout,
            commandType: CommandType.Text
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