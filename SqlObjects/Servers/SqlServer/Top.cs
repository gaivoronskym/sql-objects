using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Servers.SqlServer;

/// <summary>
/// TOP [...] query
/// </summary>
/// <param name="rows"></param>
public sealed class Top(int rows) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "TOP({0})",
            rows
        ).AsString();
    }
}