using SqlObjects.Text;
using Yaapii.Atoms.Enumerable;

namespace SqlObjects.Common;

public sealed class JoinedQueries : QueryEnvelope
{
    public JoinedQueries(params IQuery[] origin)
        : this(new ManyOf<IQuery>(origin))
    {
    }

    public JoinedQueries(IQuery first, IEnumerable<IQuery> others)
        : this(
            new Joined<IQuery>(
                first,
                others
            )
        )
    {
    }

    public JoinedQueries(IEnumerable<IQuery> origin)
        : base(
            new JoinedViaEol(
                new Mapped<IQuery, string>(
                    q => q.Sql(),
                    origin
                )
            )
        )
    {
    }
}