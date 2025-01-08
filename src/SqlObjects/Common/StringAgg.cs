using SqlObjects.Scalar;
using SqlObjects.Text;
using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// STRING_AGG function
/// </summary>
/// <param name="expression">SQL expression</param>
/// <param name="separator">separator</param>
/// <param name="alias">alias</param>
public sealed class StringAgg(IQuery expression, string separator, string alias) : QueryEnvelope(
    new Formatted(
        "STRING_AGG({0}, {1}){2}",
        new TextOf(expression.Sql),
        new TextOf(new SqlStringOf(separator).Sql),
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
    public StringAgg(string expression, string separator)
        : this(expression, separator, string.Empty)
    {

    }

    public StringAgg(string expression, string separator, string alias)
        : this(new QueryOf(expression), separator, alias)
    {

    }

    public StringAgg(IQuery expression, string separator)
        : this(expression, separator, string.Empty)
    {

    }
}