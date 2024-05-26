using SqlObjects.Interfaces;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;
using JoinedQueries = Yaapii.Atoms.Enumerable.Joined<SqlObjects.Interfaces.IQuery>; 

namespace SqlObjects;

public sealed class Columns : ListEnvelope<IQuery>
{
    public Columns(params string[] array) : this(new LiveMany<IQuery>(array.Select(a => new RawSql(a)).GetEnumerator))
    { }
    
    public Columns(params IQuery[] src) : base(() => src, false)
    { }
    
    public Columns(IEnumerable<string> columns, params IQuery[] queries) 
        : base(
        () => new JoinedQueries(
                columns.Select(c => new RawSql(c)),
                queries
            ).GetEnumerator(), false)
    { }
    
    public Columns(IEnumerator<IQuery> src) : base(() => src, false)
    { }
    
    public Columns(IEnumerable<IQuery> src) : base(
        () => src.GetEnumerator(),
        false
    )
    { }
}