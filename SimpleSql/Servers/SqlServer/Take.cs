using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public sealed class Take(int rows) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "FETCH NEXT {0} ROWS ONLY",
            rows
        ).AsString();
    }
}