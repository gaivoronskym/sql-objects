using SimpleSql.Interfaces;
using SimpleSql.Types;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class IsNull(IQuery query) : IQuery
{
    public IsNull(string field)
        : this(new RawSql(field))
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "{0} IS {1}",
            query.Raw(),
            new SqlNull().Raw()
        ).AsString();
    }
}