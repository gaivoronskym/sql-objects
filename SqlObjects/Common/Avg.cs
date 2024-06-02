using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// AVG function
/// </summary>
/// <param name="query"></param>
/// <param name="alias"></param>
public sealed class Avg(IQuery query, string alias) : IQuery
{
    public Avg(IQuery query)
        : this(query, string.Empty)
    {
        
    }

    public Avg(string query)
        : this(query, string.Empty)
    {
        
    }
    
    public Avg(string query, string alias)
        : this(new RawSql(query), alias)
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "AVG({0}){1}",
            new TextOf(query.Raw()),
            new TextIf(
                !string.IsNullOrEmpty(alias),
                new Formatted(
                    " AS {0}",
                    alias
                )
            )
        ).AsString();
    }
}