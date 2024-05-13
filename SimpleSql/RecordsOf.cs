﻿using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;

namespace SimpleSql;

public sealed class RecordsOf : ListEnvelope<ISqlParams>
{
    public RecordsOf(params ISqlParams[] array) : this(new LiveMany<ISqlParams>(array))
    { }
    
    public RecordsOf(IEnumerator<ISqlParams> src) : base(() => src, false)
    { }
    
    public RecordsOf(IEnumerable<ISqlParams> src) : base(
        () => src.GetEnumerator(),
        false
    )
    { }
}