using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class And : IQuery
{
    private readonly IQuery _query;

    public And(IQuery query)
    {
        _query = query;
    }

    public string Raw()
    {
        return new Formatted(
            "AND {0}",
            _query.Raw()
        ).AsString();
    }
}