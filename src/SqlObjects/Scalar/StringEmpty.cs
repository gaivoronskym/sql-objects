using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SqlObjects.Scalar;

public sealed class StringEmpty(Func<IText> func) : IScalar<bool>
{
    public StringEmpty(Func<string> func)
        : this(new TextOf(func))
    {
    }
    
    public StringEmpty(string text)
        : this(new TextOf(text))
    {
    }
    
    public StringEmpty(IText text)
        : this(() => text)
    {
    }

    public bool Value()
    {
        return string.IsNullOrEmpty(func().AsString());
    }
}