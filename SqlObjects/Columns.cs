using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects;

public sealed class Columns(IEnumerable<IQuery> queries) : IQuery
{
    public Columns(IEnumerable<string> queries)
        : this(queries.Select(q => new RawSql(q)))
    {
    }

    public string Raw()
    {
        return new Joined(
            ",\r\n",
            queries.Select(q => q.Raw())
        ).AsString();
    }
}