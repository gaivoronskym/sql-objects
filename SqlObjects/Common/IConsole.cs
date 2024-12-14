using System.Data;
using Dapper;
using SqlObjects.Interfaces;
using Yaapii.Atoms.Enumerable;

namespace SqlObjects.Common;

public sealed class DbConsole : IConsole
{
    private readonly IDbConnection conn;

    public DbConsole(IDbConnection conn)
    {
        this.conn = conn;
    }

    public IEnumerable<IRow> Exec(IQuery query)
    {
        var res = conn.Query(
            sql: query.Raw()
        ).Cast<IDictionary<string, object>>();

        return new ManyOf<IRow>(
            new Mapped<IDictionary<string, object>, IRow>(
                i => new Row(i),
                res
            )
        );
    }
}