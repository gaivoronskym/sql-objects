using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public class Having : IQuery
{
    private readonly IEnumerable<IQuery> _queries;

    public Having(params string[] raw)
        : this(raw.Select(r => new RawSql(r)))
    {
        
    }
    
    public Having(IEnumerable<IQuery> queries)
    {
        _queries = queries;
    }
    
    public string Raw()
    {
        return new Formatted(
            "HAVING {0}",
            new Joined(", ", _queries.Select(q => q.Raw()))
        ).AsString();
    }
}