using SimpleSql.Types;
using Yaapii.Atoms.Text;

namespace SimpleSql;

public sealed class IsNotNull : IQuery
{
    private readonly IQuery _query;

    public IsNotNull(IQuery query)
    {
        _query = query;
    }

    public IsNotNull(string field)
        : this(new RawSql(field))
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "{0} IS NOT {1}",
            _query.Raw(),
            new SqlNull().Raw()
        ).AsString();
    }
}