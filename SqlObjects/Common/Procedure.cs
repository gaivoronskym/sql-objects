using SqlObjects.Interfaces;
using SqlObjects.Text;
using Yaapii.Atoms;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Scalar;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Common;

/// <summary>
/// Executes stored procedure
/// </summary>
/// <param name="name"></param>
/// <param name="sqlParams"></param>
public sealed class Procedure(string name, IEnumerable<ISqlParam> sqlParams) : QueryEnvelope(
    new Formatted(
        "EXEC {0}{1};",
        new TextOf(name),
        new TextIf(
            new ScalarOf<bool>(sqlParams.Any),
            new EolWithText(
                new Joined(
                    new Formatted(",{0}", Environment.NewLine),
                    new Mapped<ISqlParam, IText>(
                        (p) => new Formatted("@{0} = {1}", p.Key(), p.Query().Raw()),
                        sqlParams
                    )
                )
            )
        )
    )
);