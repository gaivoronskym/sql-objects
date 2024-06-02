using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;
/// <summary>
/// SUM function
/// </summary>
/// <param name="query">expression</param>
/// <param name="alias">alias</param>
public sealed class Sum(IQuery query, string alias) : IQuery
{

    public Sum(IQuery query)
        : this(query, string.Empty)
    {
        
    }

    public Sum(string query)
        : this(query, string.Empty)
    {
        
    }
    
    public Sum(string query, string alias)
        : this(new RawSql(query), alias)
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "SUM({0}){1}",
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