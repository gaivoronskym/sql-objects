using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Servers.SqlServer;

public sealed class DeclareOf(string name, string type) : IQuery
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