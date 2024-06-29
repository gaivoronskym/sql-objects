using SqlObjects.Interfaces;
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
        new Joined(
            Environment.NewLine,
            new Mapped<IQuery, string>(
                (query) => query.Raw(),
                queries
            )
        ),
        new TextOf(")")
    )
);