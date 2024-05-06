using SimpleSql.Types;
using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SimpleSql;

public sealed class In(IQuery field, IQuery query) : IQuery
{
    public In(string field, params int[] values)
        : this(
            new RawSql(field),
            new SqlCollection(values.Select(v => new SqlIntOf(v)))
        )
    {

    }
    
    public In(string field, params long[] values)
        : this(
            new RawSql(field),
            new SqlCollection(values.Select(v => new SqlBigintOf(v)))
        )
    {

    }
    
    public In(string field, IEnumerable<string> values)
        : this(
            new RawSql(field),
            new SqlCollection(values.Select(v => new SqlStringOf(v)))
        )
    {

    }

    public string Raw()
    {
        return new Formatted(
            "{0} IN {1}",
            field.Raw(),
            query.Raw()
        ).AsString();
    }
}