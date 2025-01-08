using SqlObjects.Scalar;
using SqlObjects.Text;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

public abstract class Join
    (string table, string first, string second, string type, IQuery query, string operation = "=") : QueryEnvelope(
        new JoinedViaBlank(
            new Formatted(
                "{0} JOIN {1} ON {2} {3} {4}",
                type,
                table,
                first,
                operation,
                second
            ),
            new TextIf(
                new StringFilled(query.Sql),
                new EolWithText(
                    new TextOf(
                        query.Sql
                    )
                )
            )
        )
    );