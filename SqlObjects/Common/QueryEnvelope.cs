using SqlObjects.Interfaces;
using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

public abstract class QueryEnvelope(Func<IText> func) : IQuery
{
    protected QueryEnvelope(string text)
        : this(new TextOf(text))
    {
    }
    
    protected QueryEnvelope(IText text)
        : this(() => text)
    {
    }
    
    public string Raw()
    {
        return func().AsString();
    }
}