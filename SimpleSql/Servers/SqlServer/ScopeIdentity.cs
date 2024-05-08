using SimpleSql.Interfaces;

namespace SimpleSql.Servers.SqlServer;

public class ScopeIdentity : IQuery
{
    public string Raw()
    {
        return "SELECT scope_identity() as Id;";
    }
}