using SimpleSql.Interfaces;
using SimpleSql.Types;

namespace SimpleSql;

public sealed class SqlParam(string key, IQuery query) : ISqlParam
{
    public SqlParam(string key, long value)
        : this(key, new SqlBigintOf(value))
    {
        
    }
    
    public SqlParam(string key, int value)
        : this(key, new SqlIntOf(value))
    {
        
    }
    
    public SqlParam(string key, string value)
        : this(key, new SqlStringOf(value))
    {
        
    }
    
    public SqlParam(string key, decimal value)
        : this(key, new SqlDecimalOf(value))
    {
        
    }
    
    public SqlParam(string key, bool value)
        : this(key, new SqlBoolOf(value))
    {
        
    }
    
    public string Key()
    {
        return key;
    }

    public IQuery Query()
    {
        return query;
    }
}