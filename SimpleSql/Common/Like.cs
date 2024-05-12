using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class Like(IQuery field, IQuery query) : IQuery
{
    public Like(string field, string query)
        : this(new RawSql(field), new RawSql(query))
    {
        
    }

    public string Raw()
    {
        var sql = query.Raw();
        var withParams = new Contains(sql, "%");
        if (withParams.Value())
        {
            return new Formatted(
                "{0} LIKE '{1}'",
                field.Raw(),
                sql
            ).AsString();
        }

        return new Formatted(
            "{0} LIKE '%{1}%'",
            field.Raw(),
            sql
        ).AsString();
    }
}