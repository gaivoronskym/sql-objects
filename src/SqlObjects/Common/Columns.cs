using Yaapii.Atoms;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Common;

public sealed class Columns : QueryEnvelope
{
    public Columns(params string[] columns)
        : this(new ManyOf(columns))
    {
    }

    public Columns(IEnumerable<string> columns)
        : this(
            new Mapped<string, IQuery>(
                c => new QueryOf(c),
                columns
            )
        )
    {
    }

    public Columns(params IQuery[] columns)
        : this(new ManyOf<IQuery>(columns))
    {
    }

    public Columns(IEnumerable<IQuery> columns)
        : base(
            new Joined(
                ",\r\n",
                new Mapped<IQuery, IText>(
                    q => new TextOf(q.Sql),
                    columns
                )
            )
        )
    {
    }
}