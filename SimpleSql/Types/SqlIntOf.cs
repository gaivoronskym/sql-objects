using SimpleSql.Interfaces;

namespace SimpleSql.Types;

public sealed class SqlIntOf(int val) : IQuery
{
    public string Raw()
    {
        return val.ToString();
    }
}