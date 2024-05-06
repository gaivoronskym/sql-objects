using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SimpleSql;

public sealed class RawSql(IText val) : IQuery
{
    public RawSql(string val)
        : this(new TextOf(val))
    {
    }

    public string Raw()
    {
        return val.AsString();
    }
}