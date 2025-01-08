using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SqlObjects.Scalar;

public sealed class StringFilled(Func<IText> func) : IScalar<bool>
{
    public StringFilled(Func<string> func)
        : this(new TextOf(func))
    {
    }
    
    public StringFilled(string text)
        : this(new TextOf(text))
    {
    }
    
    public StringFilled(IText text)
        : this(() => text)
    {
    }


    public bool Value()
    {
        return !string.IsNullOrEmpty(func().AsString());
    }
}