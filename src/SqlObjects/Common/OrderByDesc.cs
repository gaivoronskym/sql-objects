namespace SqlObjects.Common;

/// <summary>
/// ORDER BY ... DESC query
/// </summary>
public sealed class OrderByDesc : OrderBy
{
    public OrderByDesc(params IQuery[] queries)
        : base(queries, "DESC")
    {
        
    }
    
    public OrderByDesc(params string[] fields)
        : base(fields.Select(f => new QueryOf(f)), "DESC")
    {
        
    }
}