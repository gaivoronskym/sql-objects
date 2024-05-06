namespace SimpleSql.Servers.SqlServer;

public class OrderByDesc : OrderBy
{
    public OrderByDesc(params IQuery[] queries)
        : base(queries, "DESC")
    {
        
    }
    
    public OrderByDesc(params string[] fields)
        : base(fields.Select(f => new RawSql(f)), "DESC")
    {
        
    }
}