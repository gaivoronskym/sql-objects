using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class Brackets(params IQuery[] queries) : IQuery
{
    private readonly IEnumerable<IQuery> _queries = queries;

    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            true,
            new TextOf("("),
            new Joined(Environment.NewLine, _queries.Select(q => q.Raw()), true),
            new TextOf(")")
        ).AsString();
    }
}