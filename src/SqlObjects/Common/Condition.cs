using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// SQL boolean expression
/// </summary>
public sealed class Condition : QueryEnvelope
{
    public Condition(IQuery first, IQuery second)
        : this(first, "=", second)
    {
    }

    public Condition(string first, string operation, IQuery second)
        : this(new QueryOf(first), operation, second)
    {
    }
    
    public Condition(string first, IQuery second)
        : this(new QueryOf(first), "=", second)
    {
    }

    public Condition(string first, long second)
        : this(first, new SqlBigintOf(second))
    {
    }
    
    public Condition(string first, int second)
        : this(first, new SqlIntOf(second))
    {
    }
    
    public Condition(string first, string second)
        : this(first, new SqlStringOf(second))
    {
    }
    
    public Condition(string first, decimal second)
        : this(first, new SqlDecimalOf(second))
    {
    }
    
    public Condition(string first, bool second)
        : this(first, new SqlBoolOf(second))
    {
    }
    
    public Condition(string first, string operation, long second)
        : this(first, operation, new SqlBigintOf(second))
    {
    }
    
    public Condition(string first, string operation, int second)
        : this(first, operation, new SqlIntOf(second))
    {
    }
    
    public Condition(string first, string operation, decimal second)
        : this(first, operation, new SqlDecimalOf(second))
    {
    }
    
    public Condition(string field, string operation, string second)
        : this(field, operation, new SqlStringOf(second))
    {
    }
    
    public Condition(string field, string operation, bool second)
        : this(field, operation, new SqlBoolOf(second))
    {
    }
    
    public Condition(IQuery first, string operation, long second)
        : this(first, operation, new SqlBigintOf(second))
    {
    }
    
    public Condition(IQuery first, string operation, int second)
        : this(first, operation, new SqlIntOf(second))
    {
    }
    
    public Condition(IQuery first, string operation, decimal second)
        : this(first, operation, new SqlDecimalOf(second))
    {
    }
    
    public Condition(IQuery first, string operation, string second)
        : this(first, operation, new SqlStringOf(second))
    {
    }
    
    public Condition(IQuery first, string operation, bool second)
        : this(first, operation, new SqlBoolOf(second))
    {
    }
    
    public Condition(IQuery first, string operation, IQuery second)
        : base(
            new Formatted(
                "{0} {1} {2}",
                false,
                new TextOf(first.Sql()),
                new TextOf(operation),
                new TextOf(second.Sql())
            )
        )
    {
    }
}
