using SqlObjects.Interfaces;
using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// IS NOT NULL query
/// </summary>
/// <param name="expression"></param>
public sealed class IsNotNull(IQuery expression) : IQuery
{
    public IsNotNull(string expression)
        : this(new RawSql(expression))
    {
    }

    public string Raw()
    {
        return new Formatted(
            "{0} IS NOT {1}",
            expression.Raw(),
            new SqlNull().Raw()
        ).AsString();
    }
}