using ElegantSql.Common;
using ElegantSql.Interfaces;
using Yaapii.Atoms.Text;

namespace ElegantSql;

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