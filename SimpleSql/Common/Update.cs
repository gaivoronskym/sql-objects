using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class Update(string table, IEnumerable<ISqlParam> @params, IEnumerable<IQuery> queries)
    : IQuery
{
    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            new Formatted(
                "UPDATE {0} SET {1}",
                new TextOf(table),
                new Joined(
                    ", ",
                    @params.Select(p => new Formatted("{0} = {1}", p.Key(), p.Query().Raw()))
                )
            ),
            new Joined(
                Environment.NewLine,
                queries.Select(q => q.Raw())
            ),
            new TextOf(";")
        ).AsString();
    }
}