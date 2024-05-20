using ElegantSql.Interfaces;
using ElegantSql.Types;
using Yaapii.Atoms.Text;

namespace ElegantSql.Servers.SqlServer;

/// <summary>
/// SET [name] = [SQL_expression]; query
/// </summary>
/// <param name="name"></param>
/// <param name="expression"></param>
public sealed class SetOf(string name, IQuery expression) : IQuery
{
    public SetOf(string name, bool value)
        :  this(name, new SqlBoolOf(value))
    {
        
    }
    
    public SetOf(string name, DateTime value)
        :  this(name, new SqlDatetimeOf(value))
    {
        
    }
    
    public SetOf(string name, int value)
        :  this(name, new SqlIntOf(value))
    {
        
    }
    
    public SetOf(string name, long value)
        :  this(name, new SqlBigintOf(value))
    {
        
    }
    
    public SetOf(string name, string value)
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