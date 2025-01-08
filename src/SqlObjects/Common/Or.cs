using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// OR query
/// </summary>
/// <param name="expression">SQL expression</param>
public sealed class Or(IQuery expression) : QueryEnvelope(
    new Formatted(
        "OR {0}",
        expression.Sql()
    )
)
{
    public Or(string first, string operation, string second)
        : this(new QueryOf(first), operation, new QueryOf(second))
    {
    }

    public Or(string first, int second)
        : this(first, new SqlIntOf(second))
    {
    }

    public Or(string first, string second)
        : this(first, new SqlStringOf(second))
    {
    }

    public Or(string first, decimal second)
        : this(first, new SqlDecimalOf(second))
    {
    }

    public Or(string first, bool second)
        : this(first, new SqlBoolOf(second))
    {
    }

    public Or(string first, string operation, long second)
        : this(first, operation, new SqlBigintOf(second))
    {
    }

    public Or(string first, string operation, int second)
        : this(first, operation, new SqlIntOf(second))
    {
    }

    public Or(string first, string operation, decimal second)
        : this(first, operation, new SqlDecimalOf(second))
    {
    }

    public Or(string first, string operation, bool second)
        : this(first, operation, new SqlBoolOf(second))
    {
    }

    public Or(string first, string operation, IQuery second)
        : this(new QueryOf(first), operation, second)
    {
    }

    public Or(string first, IQuery second)
        : this(new QueryOf(first), second)
    {
    }

    public Or(IQuery first, IQuery second)
        : this(first, "=", second)
    {
    }

    public Or(IQuery first, string operation, IQuery second)
        : this(new Condition(first, operation, second))
    {
    }
}