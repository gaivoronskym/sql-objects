using SqlObjects.Interfaces;
using SqlObjects.Scalar;
using SqlObjects.Text;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// AVG function
/// </summary>
/// <param name="query"></param>
/// <param name="alias"></param>
public sealed class Avg(IQuery query, string alias) : QueryEnvelope(
    new Formatted(
        "AVG({0}){1}",
        new TextOf(query.Raw()),
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
}