using SqlObjects.Interfaces;
using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// IN (...) query
/// </summary>
/// <param name="expression">SQL expression</param>
/// <param name="values">list of values</param>
public sealed class In(IQuery expression, IQuery values) : IQuery
{
    public In(string field, IEnumerable<int> values)
        : this(
            new RawSql(field),
            new Many(values.Select(v => new SqlIntOf(v)))
        )
    {
    }
    
    public In(string field, IEnumerable<long> values)
        : this(
            new RawSql(field),
            new Many(values.Select(v => new SqlBigintOf(v)))
        )
    {
    }
    
    public In(string field, IEnumerable<string> values)
        : this(
            new RawSql(field),
            new Many(values.Select(v => new SqlStringOf(v)))
        )
    {
    }

    public string Raw()
    {
        return new Formatted(
            "{0} IN {1}",
            expression.Raw(),
            values.Raw()
        ).AsString();
    }
}