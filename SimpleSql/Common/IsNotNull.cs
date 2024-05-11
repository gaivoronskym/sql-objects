using SimpleSql.Interfaces;
using SimpleSql.Types;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class IsNotNull(IQuery query) : IQuery
{
    public IsNotNull(string field)
        : this(new RawSql(field))
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "{0} IS NOT {1}",
            query.Raw(),
            new SqlNull().Raw()
        ).AsString();
    }
}