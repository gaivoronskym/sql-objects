using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class SumOf(IQuery query, string alias) : IQuery
{

    public SumOf(IQuery query)
        : this(query, string.Empty)
    {
        
    }

    public SumOf(string query)
        : this(query, string.Empty)
    {
        
    }
    
    public SumOf(string query, string alias)
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