using SqlObjects.Types;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// IN (...) query
/// </summary>
/// <param name="expression">SQL expression</param>
/// <param name="values">list of values</param>
public sealed class In : QueryEnvelope
{
    public In(string field, IEnumerable<int> values)
        : this(
            new QueryOf(field),
            new Many(values.Select(v => new SqlIntOf(v)))
        )
    {
    }
    
    public In(string field, IEnumerable<long> values)
        : this(
            new QueryOf(field),
            new Many(values.Select(v => new SqlBigintOf(v)))
        )
    {
    }
    
    public In(string field, IEnumerable<string> values)
        : this(
            new QueryOf(field),
            new Many(values.Select(v => new SqlStringOf(v)))
        )
    {
    }
    
    public In(IQuery expression, IQuery values)
        : base(
            new Formatted(
                "{0} IN {1}",
                expression.Sql(),
                values.Sql()
            )
        )
    {
    }
}