using SimpleSql.Interfaces;

namespace SimpleSql.Servers.SqlServer;

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