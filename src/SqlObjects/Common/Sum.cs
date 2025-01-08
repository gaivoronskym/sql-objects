using SqlObjects.Scalar;
using SqlObjects.Text;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;
/// <summary>
/// SUM function
/// </summary>
public sealed class Sum : QueryEnvelope
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
        : this(new QueryOf(query), alias)
    {
    }

    public Sum(IQuery query, string alias)
        : base(
            new Formatted(
                "SUM({0}){1}",
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