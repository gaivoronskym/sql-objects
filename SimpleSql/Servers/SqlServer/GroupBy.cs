using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public class GroupBy : IQuery
{
    private readonly IEnumerable<IQuery> _queries;

    public GroupBy(params string[] fields)
        : this(fields.Select(f => new RawSql(f)))
    {
        
    }
    
    public GroupBy(IEnumerable<IQuery> queries)
    {
        _queries = queries;
    }

    public string Raw()
    {
        return new Formatted(
            "GROUP BY {0}",
            new Joined(", ", _queries.Select(q => q.Raw()))
        ).AsString();
    }
}