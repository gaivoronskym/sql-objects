using SimpleSql.Interfaces;
using SimpleSql.Types;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class Condition(IQuery field, string operation, IQuery value) : IQuery
{
    public Condition(IQuery field, IQuery value)
        : this(field, "=", value)
    {

    }

    public Condition(string field, string operation, IQuery value)
        : this(new RawSql(field), operation, value)
    {
        
    }
    
    public Condition(string field, IQuery value)
        : this(new RawSql(field), "=", value)
    {

    }

    public Condition(string field, long value)
        : this(field, new SqlBigintOf(value))
    {
        
    }
    
    public Condition(string field, int value)
        : this(field, new SqlIntOf(value))
    {
        
    }
    
    public Condition(string field, string value)
        : this(field, new SqlStringOf(value))
    {
        
    }
    
    public Condition(string field, decimal value)
        : this(field, new SqlDecimalOf(value))
    {
        
    }
    
    public Condition(string field, bool value)
        : this(field, new SqlBoolOf(value))
    {
        
    }
    
    public Condition(string field, string operation, long value)
        : this(field, operation, new SqlBigintOf(value))
    {
        
    }
    
    public Condition(string field, string operation, int value)
        : this(field, operation, new SqlIntOf(value))
    {
        
    }
    
    public Condition(string field, string operation, decimal value)
        : this(field, operation, new SqlDecimalOf(value))
    {
        
    }
    
    public Condition(string field, string operation, string value)
        : this(field, operation, new SqlStringOf(value))
    {
        
    }
    
    public Condition(string field, string operation, bool value)
        : this(field, operation, new SqlBoolOf(value))
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "{0} {1} {2}",
            true,
            new TextOf(field.Raw),
            new TextOf(operation),
            new TextOf(value.Raw())
        ).AsString();
    }
}
