using SqlObjects.Text;
using Yaapii.Atoms;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Scalar;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// Deletes data from [Table_Name]
/// </summary>
/// <param name="from"></param>
/// <param name="queries"></param>
public sealed class Delete(string from, params IQuery[] queries) : QueryEnvelope(
    new TextWithSemicolon(
        new Formatted(
            "DELETE FROM {0}{1}",
            new TextOf(from),
            new TextIf(
                new ScalarOf<bool>(queries.Any),
                new EolWithText(
                    new JoinedViaEol(
                        new Mapped<IQuery, IText>(
                            (query) => new TextOf(query.Sql),
                            queries
                        )
                    )
                )
            )
        )
    )
);