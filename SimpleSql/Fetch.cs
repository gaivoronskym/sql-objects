using System.Collections;
using System.Data;
using Dapper;
using SimpleSql.Interfaces;

namespace SimpleSql;

public class Fetch : IFetch
{
    private readonly IDbConnection _connection;
    private readonly IQuery _query;
    private readonly int _timeout;

    public Fetch(IDbConnection connection, IQuery query)
        : this(connection, query, 30)
    {
        
    }

    public Fetch(IDbConnection connection, IQuery query, int timeout)
    {
        _connection = connection;
        _query = query;
        _timeout = timeout;
    }

    public IList<IRow> Rows()
    {
        var res = _connection.Query(
            sql: _query.Raw(),
            commandTimeout: _timeout
        ).Cast<IDictionary<string, Object>>();

        IList<IRow> rows = new List<IRow>();
        foreach (var row in res)
        {
            rows.Add(new Row(row));
        }
        
        return rows;
    }
}