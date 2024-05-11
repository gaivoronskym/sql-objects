using System.Collections;
using System.Data;
using Dapper;
using SimpleSql.Interfaces;

namespace SimpleSql;

public sealed class Fetch(IDbConnection connection, IQuery query, int timeout) : IFetch
{
    public Fetch(IDbConnection connection, IQuery query)
        : this(connection, query, 30)
    {
        
    }

    public IList<IRow> Rows()
    {
        var res = connection.Query(
            sql: query.Raw(),
            commandTimeout: timeout
        ).Cast<IDictionary<string, Object>>();

        IList<IRow> rows = new List<IRow>();
        foreach (var row in res)
        {
            rows.Add(new Row(row));
        }
        
        return rows;
    }
}