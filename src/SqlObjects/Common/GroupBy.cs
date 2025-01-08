using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// GROUP BY query
/// </summary>
/// <param name="expressions"></param>
public sealed class GroupBy(IEnumerable<IQuery> expressions) : QueryEnvelope(
    new Formatted(
        "GROUP BY {0}",
        new Joined(", ", expressions.Select(q => q.Sql()))
    )
)
{
    public GroupBy(params string[] expressions)
        : this(expressions.Select(f => new QueryOf(f)))
    {

    }
}