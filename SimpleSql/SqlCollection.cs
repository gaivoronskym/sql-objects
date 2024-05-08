using SimpleSql.Common;
using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql;

public sealed class SqlCollection(IEnumerable<IQuery> queries) : IQuery
{
    public string Raw()
    {
        return new Brackets(
            new RawSql(
                new Joined(
                    ",",
                    queries.Select(q => q.Raw())
                )
            )
        ).Raw();
    }
}