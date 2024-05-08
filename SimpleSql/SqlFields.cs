using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;

namespace SimpleSql;

public sealed class SqlFields : ListEnvelope<IQuery>
{
    public SqlFields(params string[] array) : this(new LiveMany<IQuery>(array.Select(a => new RawSql(a)).GetEnumerator))
    { }
    
    public SqlFields(IEnumerator<IQuery> src) : base(() => src, false)
    { }
    
    public SqlFields(IEnumerable<IQuery> src) : base(
        () => src.GetEnumerator(),
        false
    )
    { }
}