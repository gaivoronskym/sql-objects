using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public class Skip : IQuery
{
    private readonly int _rows;

    public Skip(int rows)
    {
        _rows = rows;
    }

    public string Raw()
    {
        return new Formatted(
            "OFFSET {0} ROWS",
            _rows
        ).AsString();
    }
}