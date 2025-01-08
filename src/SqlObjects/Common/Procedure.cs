using SqlObjects.Text;
using Yaapii.Atoms.List;
using Yaapii.Atoms.Scalar;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;
using Mapped = Yaapii.Atoms.Enumerable.Mapped<SqlObjects.ISqlParam, Yaapii.Atoms.IText>;

namespace SqlObjects.Common;

/// <summary>
/// Stored procedure
/// </summary>
public sealed class Procedure : QueryEnvelope
{
    public Procedure(string name, params ISqlParam[] sqlParams)
        : this(name, new ListOf<ISqlParam>(sqlParams))
    {
    }

    public Procedure(string name, IList<ISqlParam> sqlParams)
        : base(
            new Formatted(
                "EXEC {0}{1};",
                new TextOf(name),
                new TextIf(
                    new ScalarOf<bool>(() => sqlParams.Any()),
                    new EolWithText(
                        new Joined(
                            new Formatted(",{0}", Environment.NewLine),
                            new Mapped(
                                (p) => new Formatted("@{0} = {1}", p.Name(), p.Value().Sql()),
                                sqlParams
                            )
                        )
                    )
                )
            )
        )
    {
    }

}