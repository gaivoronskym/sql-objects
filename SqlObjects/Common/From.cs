using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

public sealed class From(IQuery query) : QueryEnvelope(
    new Formatted(
        "FROM {0}",
        query.Raw()
    )
)
{
    public From(string query)
        : this(new RawSql(query))
    {
    }
}