using SqlObjects.Common;
using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.SqlServer;

public abstract class OrderBy(IEnumerable<IQuery> queries, string type) : QueryEnvelope(
    new Formatted(
        "ORDER BY {0} {1}",
        new Joined(", ", queries.Select(q => q.Raw())),
        new TextOf(type)
    )
);