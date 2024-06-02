using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

public sealed class From(IQuery query) : IQuery
{
    public From(string query)
        : this(new RawSql(query))
    {
    }

    public string Raw()
    {
        return new Formatted(
            "FROM {0}",
            query.Raw()
        ).AsString();
    }
}