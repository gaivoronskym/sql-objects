using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class Like : IQuery
{
    private readonly IQuery _query;
    
    public Like(IQuery query)
    {
        _query = query;
    }

    public Like(string query)
        : this(new RawSql(query))
    {
        
    }

    public string Raw()
    {
        var sql = _query.Raw();
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