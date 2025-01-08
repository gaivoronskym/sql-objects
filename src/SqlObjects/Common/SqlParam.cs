using SqlObjects.Types;

namespace SqlObjects.Common;

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
    
    public SqlParam(string key, DateTime value)
        : this(key, new SqlDatetimeOf(value))
    {
        
    }
    
    public string Name()
    {
        return key;
    }

    public IQuery Value()
    {
        return query;
    }
}