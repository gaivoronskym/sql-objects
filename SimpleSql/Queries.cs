﻿using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;

namespace SimpleSql;

public class Queries : ListEnvelope<IQuery>
{
    public Queries(params IQuery[] array) : this(new LiveMany<IQuery>(array))
    { }
    
    public Queries(IEnumerator<IQuery> src) : base(() => src, false)
    { }
    
    public Queries(IEnumerable<IQuery> src) : base(
        () => src.GetEnumerator(),
        false
    )
    { }
}