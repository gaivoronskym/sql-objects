using SqlObjects.Interfaces;
using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// SQL boolean expression
/// </summary>
/// <param name="first">first expression</param>
/// <param name="operation">boolean operation</param>
/// <param name="second">second expression</param>
public sealed class Expression(IQuery first, string operation, IQuery second) : IQuery
{
    public Expression(IQuery first, IQuery second)
        : this(first, "=", second)
    {
    }

    public Expression(string first, string operation, IQuery second)
        : this(new RawSql(first), operation, second)
    {
    }
    
    public Expression(string first, IQuery second)
        : this(new RawSql(first), "=", second)
    {
    }

    public Expression(string first, long second)
        : this(first, new SqlBigintOf(second))
    {
    }
    
    public Expression(string first, int second)
        : this(first, new SqlIntOf(second))
    {
    }
    
    public Expression(string first, string second)
        : this(first, new SqlStringOf(second))
    {
    }
    
    public Expression(string first, decimal second)
        : this(first, new SqlDecimalOf(second))
    {
    }
    
    public Expression(string first, bool second)
        : this(first, new SqlBoolOf(second))
    {
    }
    
    public Expression(string first, string operation, long second)
        : this(first, operation, new SqlBigintOf(second))
    {
    }
    
    public Expression(string first, string operation, int second)
        : this(first, operation, new SqlIntOf(second))
    {
    }
    
    public Expression(string first, string operation, decimal second)
        : this(first, operation, new SqlDecimalOf(second))
    {
    }
    
    public Expression(string field, string operation, string second)
        : this(field, operation, new SqlStringOf(second))
    {
    }
    
    public Expression(string field, string operation, bool second)
        : this(field, operation, new SqlBoolOf(second))
    {
    }
    
    public Expression(IQuery first, string operation, long second)
        : this(first, operation, new SqlBigintOf(second))
    {
    }
    
    public Expression(IQuery first, string operation, int second)
        : this(first, operation, new SqlIntOf(second))
    {
    }
    
    public Expression(IQuery first, string operation, decimal second)
        : this(first, operation, new SqlDecimalOf(second))
    {
    }
    
    public Expression(IQuery first, string operation, string second)
        : this(first, operation, new SqlStringOf(second))
    {
    }
    
    public Expression(IQuery first, string operation, bool second)
        : this(first, operation, new SqlBoolOf(second))
    {
    }

    public string Raw()
    {
        return new Formatted(
            "{0} {1} {2}",
            true,
            new TextOf(first.Raw()),
            new TextOf(operation),
            new TextOf(second.Raw())
        ).AsString();
    }
}
