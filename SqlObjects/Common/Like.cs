using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// LIKE query
/// </summary>
/// <param name="first">first expression</param>
/// <param name="second">second expression</param>
public sealed class Like(IQuery first, IQuery second) : IQuery
{
    public Like(string field, string query)
        : this(new RawSql(field), new RawSql(query))
    {
        
    }

    public string Raw()
    {
        var sql = second.Raw();
        var withParams = new Contains(sql, "%");
        if (withParams.Value())
        {
            return new Formatted(
                "{0} LIKE '{1}'",
                first.Raw(),
                sql
            ).AsString();
        }

        return new Formatted(
            "{0} LIKE '%{1}%'",
            first.Raw(),
            sql
        ).AsString();
    }
}