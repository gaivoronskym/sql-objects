using SqlObjects.Interfaces;
using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// IS NULL query
/// </summary>
/// <param name="expression">SQL expression</param>
public sealed class IsNull(IQuery expression) : QueryEnvelope(
    new Formatted(
        "{0} IS {1}",
        expression.Raw(),
        new SqlNull().Raw()
    )
)
{
    public IsNull(string expression)
        : this(new RawSql(expression))
    {
    }
}