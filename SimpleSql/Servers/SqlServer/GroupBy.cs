using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public sealed class GroupBy(IEnumerable<IQuery> queries) : IQuery
{
    public GroupBy(params string[] fields)
        : this(fields.Select(f => new RawSql(f)))
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "GROUP BY {0}",
            new Joined(", ", queries.Select(q => q.Raw()))
        ).AsString();
    }
}