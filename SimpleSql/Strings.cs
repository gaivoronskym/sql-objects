using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;

namespace SimpleSql;

public class Strings : ListEnvelope<string>
{
    public Strings(params string[] array) : this(new LiveMany<string>(array))
    { }
    
    public Strings(IEnumerator<string> src) : base(() => src, false)
    { }
    
    public Strings(IEnumerable<string> src) : base(
        () => src.GetEnumerator(),
        false
    )
    { }
}