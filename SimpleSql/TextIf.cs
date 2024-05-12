using Yaapii.Atoms;
using Yaapii.Atoms.Scalar;
using Yaapii.Atoms.Text;

namespace SimpleSql;

public class TextIf(IScalar<bool> scalar, IText first, IText second) : IText
{
    public TextIf(bool condition, IText text)
        : this (condition, text, new Blank())
    {
        
    }
    
    public TextIf(bool condition, IText first, IText second)
        : this(new ScalarOf<bool>(condition), first, second)
    {
        
    }
    
    public TextIf(Func<bool> func, IText text)
        : this(new ScalarOf<bool>(func), text, new Blank())
    {
        
    }

    public TextIf(IScalar<bool> scalar, IText text)
        : this (scalar, text, new Blank())
    {
        
    }
    
    public string AsString()
    {
        return (scalar.Value() ? first : second).AsString();
    }
}