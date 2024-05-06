using Yaapii.Atoms.Text;

namespace SimpleSql;

public class And : IQuery
{
    private readonly IQuery _query;

    public And(IQuery query)
    {
        _query = query;
    }

    public string Raw()
    {
        return new Formatted(
            "AND {0}",
            _query.Raw()
        ).AsString();
    }
}