using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class Select : IQuery
{
    private readonly string _table;
    private readonly IEnumerable<IQuery> _fields;
    private readonly IEnumerable<IQuery> _queries;

    public Select(string table, params IQuery[] fields)
        : this(table, fields, new List<IQuery>())
    {
        
    }
    
    public Select(string table, IEnumerable<IQuery> fields)
        : this(table, fields, new List<IQuery>())
    {
        
    }
    
    public Select(string table, IEnumerable<IQuery> fields, IEnumerable<IQuery> queries)
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
            new Joined(", ", _fields.Select(f => f.Raw()), true),
            new Formatted("FROM {0}", _table),
            new Joined(Environment.NewLine, _queries.Select(q => q.Raw())),
            new TextOf(";")
        ).AsString();
    }
}