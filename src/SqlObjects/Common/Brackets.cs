using SqlObjects.Text;
using Yaapii.Atoms;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Common;

/// <summary>
/// Brackets
/// </summary>
/// <param name="queries"></param>
public sealed class Brackets(params IQuery[] queries) : QueryEnvelope(
    new Joined(
        Environment.NewLine,
        true,
        new TextOf("("),
        new JoinedViaEol(
            new Mapped<IQuery, IText>(
                query => new TextOf(query.Sql),
                queries
            )
        ),
        new TextOf(")")
    )
);