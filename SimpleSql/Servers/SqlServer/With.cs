using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public sealed class With(string name, params IQuery[] queries) : IQuery
{
    private readonly IEnumerable<IQuery> _queries = queries;

    public string Raw()
    {
        return new Formatted(
            "WITH {0} AS ({1} {2} {3})",
            new TextOf(name),
            new TextOf(Environment.NewLine),
            new Joined(Environment.NewLine, _queries.Select(q => q.Raw())),
            new TextOf(Environment.NewLine)
        ).AsString();
    }
}