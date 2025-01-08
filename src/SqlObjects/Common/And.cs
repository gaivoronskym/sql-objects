using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// AND query
/// </summary>
public sealed class And : QueryEnvelope
{
    public And(string first, string operation, string second)
        : this(new QueryOf(first), operation, new QueryOf(second))
    {
    }
    
    public And(string first, int second)
        : this(first, new SqlIntOf(second))
    {
    }
    
    public And(string first, string second)
        : this(first, new SqlStringOf(second))
    {
    }
    
    public And(string first, decimal second)
        : this(first, new SqlDecimalOf(second))
    {
    }
    
    public And(string first, bool second)
        : this(first, new SqlBoolOf(second))
    {
    }
    
    public And(string first, string operation, long second)
        : this(first, operation, new SqlBigintOf(second))
    {
    }
    
    public And(string first, string operation, int second)
        : this(first, operation, new SqlIntOf(second))
    {
    }
    
    public And(string first, string operation, decimal second)
        : this(first, operation, new SqlDecimalOf(second))
    {
    }
    
    public And(string first, string operation, bool second)
        : this(first, operation, new SqlBoolOf(second))
    {
    }

    public And(string first, string operation, IQuery second)
        : this(new QueryOf(first), operation, second)
    {
    }

    public And(string first, IQuery second)
        : this(new QueryOf(first), second)
    {
    }

    public And(IQuery first, IQuery second)
        : this(first, "=", second)
    {
    }
    
    public And(IQuery first, string operation, IQuery second)
        : this(new Condition(first, operation, second))
    {
    }
    
    public And(IQuery query)
        : base(
            new Formatted(
                "AND {0}",
                query.Sql()
            )
        )
    {
    }
}