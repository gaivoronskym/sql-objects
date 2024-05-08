using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public class SumOf : IQuery
{
    private readonly IQuery _query;
    private readonly string _alias;

    public SumOf(string query, string alias)
        : this(new RawSql(query), alias)
    {
        
    }
    
    public SumOf(IQuery query, string alias)
    {
        _query = query;
        _alias = alias;
    }

    public string Raw()
    {
        return new Formatted(
            "SUM({0}) AS {1}",
            _query.Raw(),
            _alias
        ).AsString();
    }
}