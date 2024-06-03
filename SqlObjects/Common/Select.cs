using SqlObjects.Interfaces;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Common;

/// <summary>
/// Select query
/// </summary>
/// <param name="queries">expressions</param>
public sealed class Select(IEnumerable<IQuery> queries)
    : IQuery
{
    public Select(string table, IEnumerable<IQuery> columns, params IQuery[] queries)
        : this(
            new Joined<IQuery>(
                new Queries(
                    new Columns(columns),
                    new From(table)
                ),
                queries
            )
        )
    {
    }

    public Select(string table, IEnumerable<string> columns, params IQuery[] queries)
        : this(
            new Joined<IQuery>(
                new Queries(
                    new Columns(columns),
                    new From(table)
                ),
                queries
            )
        )
    {
    }

    public Select(string table, IEnumerable<IQuery> columns)
        : this(
            new Queries(
                new Columns(columns),
                new From(table)
            )
        )
    {
    }

    public Select(string table, params string[] columns)
        : this(
            new Queries(
                new Columns(columns),
                new From(table)
            )
        )
    {
    }

    public string Raw()
    {
        return new Formatted(
            "{0}\r\n{1}",
            new TextOf("SELECT"),
            new Joined(
                "\r\n",
                queries.Select(q => q.Raw())
            )
        ).AsString();
    }
}