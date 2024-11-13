using System.Data;
using Dapper;
using SqlObjects.Interfaces;

namespace SqlObjects;

/// <summary>
/// Asynchronously returns records from database
/// </summary>
/// <param name="conn">database connection</param>
/// <param name="query">SQL query</param>
/// <param name="timeout">command timeout</param>
public sealed class AsyncFetch(IDbConnection conn, IQuery query, int timeout) : IAsyncFetch
{
    public AsyncFetch(IDbConnection conn, IQuery query)
        : this(conn, query, 30)
    {
        
    }

    public async Task<IList<IRow>> RowsAsync()
    {
        var res = await conn.QueryAsync(
            sql: query.Raw(),
            commandTimeout: timeout,
            commandType: CommandType.Text
        );
            
        var list = res.Cast<IDictionary<string, string>>();
        
        IList<IRow> rows = new List<IRow>();
        foreach (var row in list)
        {
            rows.Add(new Row(row));
        }
        
        return rows;
    }
}