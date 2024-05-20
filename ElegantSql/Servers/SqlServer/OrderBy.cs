using ElegantSql.Interfaces;
using Yaapii.Atoms.Text;

namespace ElegantSql.Servers.SqlServer;

public abstract class OrderBy(IEnumerable<IQuery> queries, string type) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "ORDER BY {0} {1}",
            new Joined(", ", queries.Select(q => q.Raw())),
            new TextOf(type)
        ).AsString();
    }
}