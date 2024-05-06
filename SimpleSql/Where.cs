using Yaapii.Atoms.Text;

namespace SimpleSql;

public class Where : IQuery
{
    private readonly IQuery _query;

    public Where(IQuery query)
    {
        _query = query;
    }

    public string Raw()
    {
        return new Formatted(
            "WHERE {0}",
            _query.Raw()
        ).AsString();
    }
}