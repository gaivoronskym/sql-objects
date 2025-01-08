using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// LIKE query
/// </summary>
/// <param name="first">first expression</param>
/// <param name="second">second expression</param>
public sealed class Like(IQuery first, IQuery second) : QueryEnvelope(
    new Formatted(
        "{0} LIKE '%{1}%'",
        first.Sql(),
        second.Sql()
    )
)
{
    public Like(string field, string query)
        : this(new QueryOf(field), new QueryOf(query))
    {
    }
}