using Yaapii.Atoms;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Common;

public sealed class Many(IEnumerable<IQuery> queries) : QueryEnvelope(
    new Formatted(
        "({0})",
        new Joined(
            ",",
            new Mapped<IQuery, IText>(
                query => new TextOf(query.Sql),
                queries
            )
        )
    )
);