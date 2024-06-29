using SqlObjects.Interfaces;
using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// NOT IN (...) query
/// </summary>
/// <param name="field"></param>
/// <param name="query"></param>
public sealed class NotIn(IQuery field, IQuery query) : QueryEnvelope(
    new Formatted(
        "{0} NOT IN {1}",
        field.Raw(),
        query.Raw()
    )
)
{
    public NotIn(string field, IEnumerable<int> values)
        : this(
            new RawSql(field),
            new Many(values.Select(v => new SqlIntOf(v)))
        )
    {
    }

    public NotIn(string field, IEnumerable<long> values)
        : this(
            new RawSql(field),
            new Many(values.Select(v => new SqlBigintOf(v)))
        )
    {
    }

    public NotIn(string field, IEnumerable<string> values)
        : this(
            new RawSql(field),
            new Many(values.Select(v => new SqlStringOf(v)))
        )
    {
    }
}