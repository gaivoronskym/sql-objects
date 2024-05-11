using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class Like(IQuery query) : IQuery
{
    public Like(string query)
        : this(new RawSql(query))
    {
        
    }

    public string Raw()
    {
        var sql = query.Raw();
        var withParams = new Contains(sql, "%");
        if (withParams.Value())
        {
            return new Formatted(
                "'{0}'",
                sql
            ).AsString();
        }

        return new Formatted(
            "'%{0}%'",
            sql
        ).AsString();
    }
}