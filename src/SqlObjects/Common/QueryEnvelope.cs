using Yaapii.Atoms;
using Yaapii.Atoms.Scalar;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

public abstract class QueryEnvelope : IQuery
{
    private readonly IScalar<IQuery> src;

    public QueryEnvelope(string text)
        : this(new TextOf(text))
    {
    }
    
    public QueryEnvelope(IText text)
        : this(() => text)
    {
    }
    
    public QueryEnvelope(Func<IText> text)
        : this(() => new QueryOf(text()))
    {
    }

    public QueryEnvelope(IQuery query)
        : this(() => query)
    {
    }
    
    protected QueryEnvelope(Func<IQuery> src)
        : this(new ScalarOf<IQuery>(src))
    {
    }
    
    protected QueryEnvelope(IScalar<IQuery> src)
    {
        this.src = src;
    }

    public string Sql()
    {
        return this.src.Value().Sql();
    }
}