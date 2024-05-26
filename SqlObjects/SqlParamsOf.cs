using SqlObjects.Interfaces;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;

namespace SqlObjects;

public sealed class SqlParamsOf : ListEnvelope<ISqlParam>, ISqlParams
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