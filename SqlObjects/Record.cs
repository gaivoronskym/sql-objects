using SqlObjects.Interfaces;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;

namespace SqlObjects;

public sealed class Record : ListEnvelope<ISqlParam>, IRecord
{
    public Record(params ISqlParam[] array) : this(new LiveMany<ISqlParam>(array))
    { }
    
    public Record(IEnumerator<ISqlParam> src) : base(() => src, false)
    { }
    
    public Record(IEnumerable<ISqlParam> src) : base(
        () => src.GetEnumerator(),
        false
    )
    { }
}