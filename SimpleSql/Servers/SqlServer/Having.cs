using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public sealed class Having(IEnumerable<IQuery> queries) : IQuery
{
    public Having(params string[] raw)
        : this(raw.Select(r => new RawSql(r)))
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "HAVING {0}",
            new Joined(", ", queries.Select(q => q.Raw()))
        ).AsString();
    }
}