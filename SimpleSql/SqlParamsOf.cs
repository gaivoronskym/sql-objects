using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;

namespace SimpleSql;

public sealed class SqlParamsOf : ListEnvelope<ISqlParam>
{
    public SqlParamsOf(params ISqlParam[] array) : this(new LiveMany<ISqlParam>(array))
    { }
    
    public SqlParamsOf(IEnumerator<ISqlParam> src) : base(() => src, false)
    { }
    
    public SqlParamsOf(IEnumerable<ISqlParam> src) : base(
        () => src.GetEnumerator(),
        false
    )
    { }
}