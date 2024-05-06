using Yaapii.Atoms.Text;

namespace SimpleSql;

public sealed class Insert(string table, IEnumerable<ISqlParam> sqlparams) : IQuery
{
    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            new Formatted("INSERT INTO {0} ({1})", new TextOf(table), new Joined(", ", sqlparams.Select(s => s.Key()))),
            new Formatted("({0})", new Joined(", ", sqlparams.Select(s => s.Query().Raw())))
        ).AsString();
    }
}