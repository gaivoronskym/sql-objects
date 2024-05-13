using SimpleSql.Interfaces;
using Yaapii.Atoms.List;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SimpleSql.Common;

/// <summary>
/// UPDATE query
/// </summary>
/// <param name="table">name of table</param>
/// <param name="params">columns and values</param>
/// <param name="queries">expressions</param>
public sealed class Update(string table, IEnumerable<ISqlParam> @params, IEnumerable<IQuery> queries)
    : IQuery
{
    public Update(string table, IEnumerable<ISqlParam> sqlParams)
        : this(table, sqlParams, new ListOf<IQuery>())
    {
        
    }
    
    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            new Formatted(
                "UPDATE {0} SET {1}{2};",
                new TextOf(table),
                new Joined(
                    ",",
                    @params.Select(p => new Formatted("{0} = {1}", p.Key(), p.Query().Raw()))
                ),
                new TextIf(
                    queries.Any(),
                    new Formatted(
                        "\r\n{0}",
                        new Joined(
                            Environment.NewLine,
                            queries.Select(q => q.Raw())
                        )
                    )
                )
            )
        ).AsString();
    }
}