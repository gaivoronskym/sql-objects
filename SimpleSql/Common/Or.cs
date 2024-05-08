using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class Or : IQuery
{
    private readonly IQuery _query;

    public Or(IQuery query)
    {
        _query = query;
    }

    public string Raw()
    {
        return new Formatted(
            "OR {0}",
            _query.Raw()
        ).AsString();
    }
}