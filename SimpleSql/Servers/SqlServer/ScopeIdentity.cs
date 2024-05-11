using SimpleSql.Interfaces;

namespace SimpleSql.Servers.SqlServer;

public sealed class ScopeIdentity : IQuery
{
    public string Raw()
    {
        return "SELECT scope_identity() as Id;";
    }
}