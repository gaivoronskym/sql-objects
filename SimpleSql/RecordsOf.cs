using SimpleSql.Interfaces;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;

namespace SimpleSql;

public class RecordsOf : ListEnvelope<ISqlParamsOf>
{
    public RecordsOf(params ISqlParamsOf[] array) : this(new LiveMany<ISqlParamsOf>(array))
    { }
    
    public RecordsOf(IEnumerator<ISqlParamsOf> src) : base(() => src, false)
    { }
    
    public RecordsOf(IEnumerable<ISqlParamsOf> src) : base(
        () => src.GetEnumerator(),
        false
    )
    { }
}