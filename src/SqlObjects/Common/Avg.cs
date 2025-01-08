using SqlObjects.Scalar;
using SqlObjects.Text;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// AVG function
/// </summary>
public sealed class Avg : QueryEnvelope
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
        : this(new QueryOf(query), alias)
    {
    }
    
    public Avg(IQuery query, string alias)
        : base(
            new Formatted(
                "AVG({0}){1}",
                new TextOf(query.Sql()),
                new TextIf(
                    new StringFilled(alias),
                    new Formatted(
                        " AS {0}",
                        alias
                    )
                )
            )
        )
    {
    }
}