using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public class With : IQuery
{
    private readonly string _name;
    private readonly IEnumerable<IQuery> _queries;
    
    public With(string name, params IQuery[] queries)
    {
        _name = name;
        _queries = queries;
    }

    public string Raw()
    {
        return new Formatted(
            "WITH {0} AS ({1} {2} {3})",
            new TextOf(_name),
            new TextOf(Environment.NewLine),
            new Joined(Environment.NewLine, _queries.Select(q => q.Raw())),
            new TextOf(Environment.NewLine)
        ).AsString();
    }
}