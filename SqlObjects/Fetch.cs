using System.Data;
using Dapper;
using SqlObjects.Interfaces;

namespace SqlObjects;

/// <summary>
/// Returns records from database
/// </summary>
public sealed class Fetch : IFetch
{
    private readonly IDbConnection conn;
    private readonly int timeout;

    public Fetch(IDbConnection conn)
        : this(conn, 30)
    {
    }

    public Fetch(IDbConnection conn, int timeout)
    {
        this.conn = conn;
        this.timeout = timeout;
    }

    public IList<IRow> Rows(IQuery query)
    {
        var res = conn.Query(
            sql: query.Raw(),
            commandTimeout: timeout
        ).Cast<IDictionary<string, object>>();

        IList<IRow> rows = new List<IRow>();
        foreach (var row in res)
        {
            rows.Add(new Row(row));
        }
        
        return rows;
    }
}