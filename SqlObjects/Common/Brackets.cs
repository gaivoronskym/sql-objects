using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// Brackets
/// </summary>
/// <param name="queries"></param>
public sealed class Brackets(params IQuery[] queries) : IQuery
{
    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            true,
            new TextOf("("),
            new Joined(Environment.NewLine, queries.Select(q => q.Raw()), true),
            new TextOf(")")
        ).AsString();
    }
}