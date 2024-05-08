using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public class QueryWrap : IQuery
{
    private readonly IEnumerable<IQuery> _queries;

    public QueryWrap(params IQuery[] queries)
    {
        _queries = queries;
    }

    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            _queries.Select(q => q.Raw())
        ).AsString();
    }
}