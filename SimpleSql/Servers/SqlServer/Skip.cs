using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

/// <summary>
/// OFFSET [...] ROWS query
/// </summary>
/// <param name="rows"></param>
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