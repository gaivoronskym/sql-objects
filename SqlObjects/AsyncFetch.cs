using System.Data;
using Dapper;
using SqlObjects.Interfaces;

namespace SqlObjects;

/// <summary>
/// Asynchronously returns records from database
/// </summary>
public sealed class AsyncFetch : IAsyncFetch
{
    private readonly IDbConnection conn;
    private readonly int timeout;

    public AsyncFetch(IDbConnection conn)
        : this(conn, 30)
    {
    }

    public AsyncFetch(IDbConnection conn, int timeout)
    {
        this.conn = conn;
        this.timeout = timeout;
    }

    public async Task<IList<IRow>> RowsAsync(IQuery query)
    {
        var res = await conn.QueryAsync(
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