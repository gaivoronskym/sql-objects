using Yaapii.Atoms.Text;

namespace SimpleSql;

public sealed class Delete(string table, params IQuery[] queries) : IQuery
{
    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            new Formatted("DELETE FROM {0}", table),
            new Joined(Environment.NewLine, queries.Select(q => q.Raw()))
        ).AsString();
    }
}