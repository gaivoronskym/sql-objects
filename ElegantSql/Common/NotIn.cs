using ElegantSql.Interfaces;
using ElegantSql.Types;
using Yaapii.Atoms.Text;

namespace ElegantSql.Common;

/// <summary>
/// NOT IN (...) query
/// </summary>
/// <param name="field"></param>
/// <param name="query"></param>
public sealed class NotIn(IQuery field, IQuery query) : IQuery
{
    public NotIn(string field, IEnumerable<int> values)
        : this(
            new RawSql(field),
            new SqlCollection(values.Select(v => new SqlIntOf(v)))
        )
    {

    }
    
    public NotIn(string field, IEnumerable<long> values)
        : this(
            new RawSql(field),
            new SqlCollection(values.Select(v => new SqlBigintOf(v)))
        )
    {

    }
    
    public NotIn(string field, IEnumerable<string> values)
        : this(
            new RawSql(field),
            new SqlCollection(values.Select(v => new SqlStringOf(v)))
        )
    {

    }

    public string Raw()
    {
        return new Formatted(
            "{0} NOT IN {1}",
            field.Raw(),
            query.Raw()
        ).AsString();
    }
}