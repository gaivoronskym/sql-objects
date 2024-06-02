using SqlObjects.Interfaces;
using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// WHERE query
/// </summary>
/// <param name="query">expression</param>
public sealed class Where(IQuery query) : IQuery
{
    public Where(string first, string operation, string second)
        : this(new RawSql(first), operation, new RawSql(second))
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
        : this(new RawSql(first), operation, second)
    {
    }

    public Where(string first, IQuery second)
        : this(new RawSql(first), second)
    {
    }

    public Where(IQuery first, IQuery second)
        : this(first, "=", second)
    {
    }
    
    public Where(IQuery first, string operation, IQuery second)
        : this(new Expression(first, operation, second))
    {
    }
    
    public string Raw()
    {
        return new Formatted(
            "WHERE {0}",
            query.Raw()
        ).AsString();
    }
}