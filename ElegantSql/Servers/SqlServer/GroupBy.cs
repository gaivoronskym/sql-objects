using ElegantSql.Interfaces;
using Yaapii.Atoms.Text;

namespace ElegantSql.Servers.SqlServer;

/// <summary>
/// GROUP BY query
/// </summary>
/// <param name="expressions"></param>
public sealed class GroupBy(IEnumerable<IQuery> expressions) : IQuery
{
    public GroupBy(params string[] expressions)
        : this(expressions.Select(f => new RawSql(f)))
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "GROUP BY {0}",
            new Joined(", ", expressions.Select(q => q.Raw()))
        ).AsString();
    }
}