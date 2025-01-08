using SqlObjects.Types;
using Yaapii.Atoms.Enumerable;

namespace SqlObjects.Common;

/// <summary>
/// WHERE query
/// </summary>
public sealed class Where : QueryEnvelope
{
    public Where(string first, string operation, string second)
        : this(new QueryOf(first), operation, new QueryOf(second))
    {
    }

    public Where(string first, int value)
        : this(first, new SqlIntOf(value))
    {
    }

    public Where(string first, string value)
        : this(first, new SqlStringOf(value))
    {
    }

    public Where(string first, decimal value)
        : this(first, new SqlDecimalOf(value))
    {
    }

    public Where(string first, bool value)
        : this(first, new SqlBoolOf(value))
    {
    }

    public Where(string first, string operation, long value)
        : this(first, operation, new SqlBigintOf(value))
    {
    }

    public Where(string first, string operation, int value)
        : this(first, operation, new SqlIntOf(value))
    {
    }

    public Where(string first, string operation, decimal value)
        : this(first, operation, new SqlDecimalOf(value))
    {
    }

    public Where(string first, string operation, bool value)
        : this(first, operation, new SqlBoolOf(value))
    {
    }

    public Where(string first, string operation, IQuery second)
        : this(new QueryOf(first), operation, second)
    {
    }

    public Where(string first, IQuery second)
        : this(new QueryOf(first), second)
    {
    }

    public Where(IQuery first, IQuery second)
        : this(first, "=", second)
    {
    }

    public Where(IQuery first, string operation, IQuery second)
        : this(new Condition(first, operation, second))
    {
    }

    public Where(params IQuery[] origin)
        : this(new ManyOf<IQuery>(origin))
    {
    }

    public Where(IEnumerable<IQuery> origin)
        : base(
            new JoinedQueries(
                new QueryOf("WHERE"),
                origin
            )
        )
    {
    }
}