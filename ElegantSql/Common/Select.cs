using ElegantSql.Interfaces;
using Yaapii.Atoms.Text;

namespace ElegantSql.Common;

/// <summary>
/// Select query
/// </summary>
/// <param name="table">name of table</param>
/// <param name="columns">list of columns</param>
/// <param name="queries">expressions</param>
public sealed class Select(string table, IQuery limit, IEnumerable<IQuery> columns, IEnumerable<IQuery> queries)
    : IQuery
{
    public Select(string table, IEnumerable<IQuery> columns, IEnumerable<IQuery> queries)
        : this(table, new IQuery.None(), columns, queries)
    {
        
    }
    
    public Select(string table, IQuery limit, params IQuery[] columns)
        : this(table, limit, columns, new List<IQuery>())
    {
        
    }
    
    public Select(string table, IQuery limit, IEnumerable<IQuery> columns)
        : this(table, limit, columns, new List<IQuery>())
    {
        
    }
    
    public Select(string table, params IQuery[] columns)
        : this(table, new IQuery.None(), columns, new List<IQuery>())
    {
        
    }
    
    public Select(string table, IEnumerable<IQuery> columns)
        : this(table, new IQuery.None(), columns, new List<IQuery>())
    {
        
    }
    
    public string Raw()
    {
        return new Formatted(
            "{0}{1};",
            new Joined(
                Environment.NewLine,
                true,
                new Formatted(
                    "{0}{1}",
                    new TextOf("SELECT"),
                    new TextIf(
                        () => !string.IsNullOrEmpty(limit.Raw()),
                        new Formatted(
                            " {0}",
                            new TextOf(limit.Raw)
                        )
                    )
                ),
                new Joined(", ", columns.Select(f => f.Raw())),
                new Formatted("FROM {0}", table)
            ),
            new TextIf(
                queries.Any(),
                new Formatted(
                    "{0}{1}",
                    new TextOf(Environment.NewLine),
                    new Joined(Environment.NewLine, queries.Select(q => q.Raw()))
                )
            )
        ).AsString();
    }
}