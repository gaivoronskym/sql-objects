using SimpleSql.Types;
using Yaapii.Atoms.Text;

namespace SimpleSql;

public sealed class IsNull : IQuery
{
    private readonly IQuery _query;

    public IsNull(IQuery query)
    {
        _query = query;
    }

    public IsNull(string field)
        : this(new RawSql(field))
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "{0} IS {1}",
            _query.Raw(),
            new SqlNull().Raw()
        ).AsString();
    }
}