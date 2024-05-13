using SimpleSql.Interfaces;

namespace SimpleSql.Servers.SqlServer;

/// <summary>
/// ORDER BY ... ASC query
/// </summary>
public sealed class OrderByAsc : OrderBy
{
    public OrderByAsc(params IQuery[] queries)
        : base(queries, "ASC")
    {
        
    }
    
    public OrderByAsc(params string[] fields)
        : base(fields.Select(f => new RawSql(f)), "ASC")
    {
        
    }
}