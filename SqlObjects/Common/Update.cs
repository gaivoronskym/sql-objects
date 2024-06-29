using SqlObjects.Interfaces;
using SqlObjects.Text;
using Yaapii.Atoms.List;
using Yaapii.Atoms.Scalar;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Common;

/// <summary>
/// UPDATE query
/// </summary>
/// <param name="from">name of table</param>
/// <param name="params">columns and values</param>
/// <param name="queries">expressions</param>
public sealed class Update(string from, IEnumerable<ISqlParam> @params, IEnumerable<IQuery> queries)
    : IQuery
{
    public Update(string from, IEnumerable<ISqlParam> @params, IQuery query)
        : this(from, @params, new Queries(query))
    {
        
    }
    
    public Update(string from, IEnumerable<ISqlParam> sqlParams)
        : this(from, sqlParams, new ListOf<IQuery>())
    {
    }
    
    public string Raw()
    {
        return new Formatted(
            "UPDATE {0} SET {1}{2};",
            new TextOf(from),
            new Joined(
                ",",
                @params.Select(p => new Formatted("{0} = {1}", p.Key(), p.Query().Raw()))
            ),
            new TextIf(
                new ScalarOf<bool>(queries.Any),
                new EolWithText(
                    new Joined(
                        Environment.NewLine,
                        queries.Select(q => q.Raw())
                    )
                )
            )
        ).AsString();
    }
}