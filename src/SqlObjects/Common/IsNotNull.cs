using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// IS NOT NULL query
/// </summary>
/// <param name="expression"></param>
public sealed class IsNotNull(IQuery expression) : QueryEnvelope(
    new Formatted(
        "{0} IS NOT {1}",
        expression.Sql(),
        new SqlNull().Sql()
    )
)
{
    public IsNotNull(string expression)
        : this(new QueryOf(expression))
    {
    }
}