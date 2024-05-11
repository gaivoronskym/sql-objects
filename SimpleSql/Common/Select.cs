using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class Select(string table, IEnumerable<IQuery> fields, IEnumerable<IQuery> queries)
    : IQuery
{
    public Select(string table, params IQuery[] fields)
        : this(table, fields, new List<IQuery>())
    {
        
    }
    
    public Select(string table, IEnumerable<IQuery> fields)
        : this(table, fields, new List<IQuery>())
    {
        
    }

    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            true,
            new TextOf("SELECT"),
            new Joined(", ", fields.Select(f => f.Raw()), true),
            new Formatted("FROM {0}", table),
            new Joined(Environment.NewLine, queries.Select(q => q.Raw())),
            new TextOf(";")
        ).AsString();
    }
}