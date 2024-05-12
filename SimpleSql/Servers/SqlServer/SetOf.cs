using SimpleSql.Interfaces;
using SimpleSql.Types;
using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public sealed class SetOf(string name, IQuery query) : IQuery
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
            query.Raw()
        ).AsString();
    }
}