using ElegantSql.Interfaces;
using Yaapii.Atoms.Text;

namespace ElegantSql.Servers.SqlServer;

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