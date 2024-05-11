using SimpleSql.Interfaces;

namespace SimpleSql.Types;

public sealed class SqlBigintOf(long val) : IQuery
{
    public string Raw()
    {
        return val.ToString();
    }
}