using Yaapii.Atoms.Text;

namespace SimpleSql;

public class Select : IQuery
{
    private readonly string _table;
    private readonly IEnumerable<string> _fields;
    private readonly IEnumerable<IQuery> _queries;

    public Select(string table, params string[] fields)
        : this(table, fields, new List<IQuery>())
    {
        
    }
    
    public Select(string table, IEnumerable<string> fields, IEnumerable<IQuery> queries)
    {
        _table = table;
        _fields = fields;
        _queries = queries;
    }

    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            true,
            new TextOf("SELECT"),
            new Joined(", ", _fields, true),
            new Formatted("FROM {0}", _table),
            new Joined(Environment.NewLine, _queries.Select(q => q.Raw()))
        ).AsString();
    }
}