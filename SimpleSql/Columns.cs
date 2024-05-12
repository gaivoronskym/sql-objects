using SimpleSql.Interfaces;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;

namespace SimpleSql;

public sealed class Columns : ListEnvelope<IQuery>
{
    public Columns(params string[] array) : this(new LiveMany<IQuery>(array.Select(a => new RawSql(a)).GetEnumerator))
    { }
    
    public Columns(params IQuery[] src) : base(() => src, false)
    { }
    
    public Columns(IEnumerator<IQuery> src) : base(() => src, false)
    { }
    
    public Columns(IEnumerable<IQuery> src) : base(
        () => src.GetEnumerator(),
        false
    )
    { }
}