using ElegantSql.Interfaces;
using ElegantSql.Types;
using Yaapii.Atoms.Text;

namespace ElegantSql.Servers.SqlServer;

/// <summary>
/// STRING_AGG function
/// </summary>
/// <param name="expression">SQL expression</param>
/// <param name="separator">separator</param>
/// <param name="alias">alias</param>
public sealed class StringAggOf(IQuery expression, string separator, string alias) : IQuery
{
    public StringAggOf(string expression, string separator)
        : this(expression, separator, string.Empty)
    {
        
    }
    
    public StringAggOf(string expression, string separator, string alias)
        : this(new RawSql(expression), separator, alias)
    {
        
    }

    public StringAggOf(IQuery expression, string separator)
        : this(expression, separator, string.Empty)
    {
        
    }
    
    public string Raw()
    {
        return new Formatted(
            "STRING_AGG({0}, {1}){2}",
            new TextOf(expression.Raw),
            new TextOf(new SqlStringOf(separator).Raw),
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