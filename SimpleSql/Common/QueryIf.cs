using SimpleSql.Interfaces;

namespace SimpleSql.Common;

/// <summary>
/// Builds SQL query according to the condition
/// </summary>
/// <param name="func">condition</param>
/// <param name="first">expression if func returns true</param>
/// <param name="second">expression if func returns false</param>
public sealed class QueryIf(Func<bool> func, IQuery first, IQuery second) : IQuery
{
    public QueryIf(bool condition, IQuery first, IQuery second)
        : this(() => condition, first, second)
    {
        
    }

    public QueryIf(bool condition, IQuery query)
        : this(condition, query, new RawSql(""))
    {
        
    }

    public QueryIf(Func<bool> func, IQuery query)
        : this(func, query, new RawSql(""))
    {
        
    }
    
    public string Raw()
    {
        return (func() ? first : second).Raw();
    }
}