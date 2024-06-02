using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Servers.SqlServer;

/// <summary>
/// DECLARE [name] [type]; query
/// </summary>
/// <param name="name">name of object</param>
/// <param name="type">type of object</param>
public sealed class Declare(string name, string type) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "DECLARE @{0} {1};",
            name,
            type
        ).AsString();
    }
}