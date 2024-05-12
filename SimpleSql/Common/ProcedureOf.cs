using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class ProcedureOf(string name, IEnumerable<ISqlParam> sqlParams) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "EXEC {0}{1};",
            new TextOf(name),
            new TextIf(
                sqlParams.Any(),
                new Formatted(
                    "\r\n{0}",
                    new Joined(
                        new Formatted(",{0}", Environment.NewLine),
                        sqlParams.Select(p => new Formatted("@{0} = {1}", p.Key(), p.Query().Raw()))
                    )
                )
            )
        ).AsString();
    }
}