using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// HAVING query
/// </summary>
/// <param name="expressions"></param>
public sealed class Having(IEnumerable<IQuery> expressions) : QueryEnvelope(
    new Formatted(
        "HAVING {0}",
        new Joined(", ", expressions.Select(q => q.Sql()))
    )
)
{
    public Having(params string[] raw)
        : this(raw.Select(r => new QueryOf(r)))
    {
    }
}