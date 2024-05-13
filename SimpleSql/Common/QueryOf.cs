using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

/// <summary>
/// Query wrapper
/// </summary>
/// <param name="queries">list of queries</param>
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