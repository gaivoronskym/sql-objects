using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public class Take : IQuery
{
    private readonly int _rows;

    public Take(int rows)
    {
        _rows = rows;
    }

    public string Raw()
    {
        return new Formatted(
            "FETCH NEXT {0} ROWS ONLY",
            _rows
        ).AsString();
    }
}