using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public sealed class Top(int rows) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "TOP {0}",
            rows
        ).AsString();
    }
}