using SqlObjects.Common;
using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.SqlServer;

/// <summary>
/// HAVING query
/// </summary>
/// <param name="expressions"></param>
public sealed class Having(IEnumerable<IQuery> expressions) : QueryEnvelope(
    new Formatted(
        "HAVING {0}",
        new Joined(", ", expressions.Select(q => q.Raw()))
    )
)
{
    public Having(params string[] raw)
        : this(raw.Select(r => new RawSql(r)))
    {
    }
}