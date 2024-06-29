using SqlObjects.Interfaces;
using SqlObjects.Scalar;
using SqlObjects.Text;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;
/// <summary>
/// SUM function
/// </summary>
/// <param name="query">expression</param>
/// <param name="alias">alias</param>
public sealed class Sum(IQuery query, string alias) : QueryEnvelope(
    new Formatted(
        "SUM({0}){1}",
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
}