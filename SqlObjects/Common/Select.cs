using SqlObjects.Interfaces;
using SqlObjects.Text;
using Yaapii.Atoms;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Common;

/// <summary>
/// Select query
/// </summary>
/// <param name="queries">expressions</param>
public sealed class Select(IEnumerable<IQuery> queries) : QueryEnvelope(
    new Formatted(
        "{0}{1}",
        new TextWithEol(
            new TextOf("SELECT")
        ),
        new JoinedViaEol(
            new Mapped<IQuery, IText>(
                (query) => new TextOf(query.Raw),
                queries
            )
        )
    )
)
{
    public Select(IEnumerable<IQuery> columns, string from, params IQuery[] queries)
        : this(
            new Joined<IQuery>(
                new Queries(
                    new Columns(columns),
                    new From(from)
                ),
                queries
            )
        )
    {
    }

    public Select(IEnumerable<string> columns, string from, params IQuery[] queries)
        : this(
            new Joined<IQuery>(
                new Queries(
                    new Columns(columns),
                    new From(from)
                ),
                queries
            )
        )
    {
    }

    public Select(IEnumerable<IQuery> columns, string from)
        : this(
            new Queries(
                new Columns(columns),
                new From(from)
            )
        )
    {
    }
}