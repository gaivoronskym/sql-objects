using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class QueryOf(params IQuery[] queries) : IQuery
{
    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            queries.Select(q => q.Raw())
        ).AsString();
    }
}