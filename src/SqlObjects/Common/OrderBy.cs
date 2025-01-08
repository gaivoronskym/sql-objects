using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

public abstract class OrderBy(IEnumerable<IQuery> queries, string type) : QueryEnvelope(
    new Formatted(
        "ORDER BY {0} {1}",
        new Joined(", ", queries.Select(q => q.Sql())),
        new TextOf(type)
    )
);