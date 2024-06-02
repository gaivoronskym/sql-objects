using SqlObjects.Interfaces;
using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Servers.SqlServer;

/// <summary>
/// SET [name] = [SQL_expression]; query
/// </summary>
/// <param name="name"></param>
/// <param name="expression"></param>
public sealed class Set(string name, IQuery expression) : IQuery
{
    public Set(string name, bool value)
        :  this(name, new SqlBoolOf(value))
    {
        
    }
    
    public Set(string name, DateTime value)
        :  this(name, new SqlDatetimeOf(value))
    {
        
    }
    
    public Set(string name, int value)
        :  this(name, new SqlIntOf(value))
    {
        
    }
    
    public Set(string name, long value)
        :  this(name, new SqlBigintOf(value))
    {
        
    }
    
    public Set(string name, string value)
        :  this(name, new SqlStringOf(value))
    {
        
    }
    
    public string Raw()
    {
        return new Formatted(
            "SET @{0} = {1};",
            name,
            expression.Raw()
        ).AsString();
    }
}