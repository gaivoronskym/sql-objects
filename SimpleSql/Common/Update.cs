using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public class Update : IQuery
{
    private readonly string _table;
    private readonly IEnumerable<ISqlParam> _params;
    private readonly IEnumerable<IQuery> _queries;

    public Update(string table, IEnumerable<ISqlParam> @params, params IQuery[] queries)
    {
        _table = table;
        _params = @params;
        _queries = queries;
    }

    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            new Formatted(
                "UPDATE {0} SET {1}",
                new TextOf(_table),
                new Joined(
                    ", ",
                    _params.Select(p => new Formatted("{0} = {1}", p.Key(), p.Query().Raw()))
                )
            ),
            new Joined(
                Environment.NewLine,
                _queries.Select(q => q.Raw())
            ),
            new TextOf(";")
        ).AsString();
    }
}