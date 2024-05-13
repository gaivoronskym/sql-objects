using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

/// <summary>
/// AVG function
/// </summary>
/// <param name="query"></param>
/// <param name="alias"></param>
public sealed class AvgOf(IQuery query, string alias) : IQuery
{

    public AvgOf(IQuery query)
        : this(query, string.Empty)
    {
        
    }

    public AvgOf(string query)
        : this(query, string.Empty)
    {
        
    }
    
    public AvgOf(string query, string alias)
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