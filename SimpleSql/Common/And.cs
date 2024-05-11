using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class And(IQuery query) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "AND {0}",
            query.Raw()
        ).AsString();
    }
}