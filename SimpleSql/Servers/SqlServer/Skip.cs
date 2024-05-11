using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public sealed class Skip(int rows) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "OFFSET {0} ROWS",
            rows
        ).AsString();
    }
}