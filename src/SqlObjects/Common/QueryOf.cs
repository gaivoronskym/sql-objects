using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// SQL query
/// </summary>
/// <param name="val"></param>
public sealed class QueryOf(IText val) : IQuery
{
    public QueryOf(string val)
        : this(new TextOf(val))
    {
    }

    public string Sql()
    {
        return val.AsString();
    }
}