using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class SumOf(IQuery query, string alias) : IQuery
{
    public SumOf(string query, string alias)
        : this(new RawSql(query), alias)
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "SUM({0}) AS {1}",
            query.Raw(),
            alias
        ).AsString();
    }
}