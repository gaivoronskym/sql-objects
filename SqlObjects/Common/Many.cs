using SqlObjects.Interfaces;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Common;

public sealed class Many(IEnumerable<IQuery> queries) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "({0})",
            new Joined(
                ",",
                new Mapped<IQuery, string>(
                    query => query.Raw(),
                    queries
                )
            )
        ).AsString();
    }
}