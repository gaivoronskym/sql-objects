using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public class Top : IQuery
{
    private readonly int _rows;

    public Top(int rows)
    {
        _rows = rows;
    }

    public string Raw()
    {
        return new Formatted(
            "TOP {0}",
            _rows
        ).AsString();
    }
}