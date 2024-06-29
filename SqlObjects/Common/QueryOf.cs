using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// Query wrapper
/// </summary>
/// <param name="queries">list of queries</param>
public sealed class QueryOf(IEnumerable<IQuery> queries) : QueryEnvelope(
    () => new Joined(
        Environment.NewLine,
        queries.Select(q => q.Raw())
    )
);