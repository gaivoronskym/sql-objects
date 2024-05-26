using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;

namespace SqlObjects;

public sealed class StringsOf : ListEnvelope<string>
{
    public StringsOf(params string[] array) : this(new LiveMany<string>(array))
    { }
    
    public StringsOf(IEnumerator<string> src) : base(() => src, false)
    { }
    
    public StringsOf(IEnumerable<string> src) : base(
        () => src.GetEnumerator(),
        false
    )
    { }
}