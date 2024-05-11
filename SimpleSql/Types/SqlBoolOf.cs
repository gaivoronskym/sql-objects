using SimpleSql.Interfaces;

namespace SimpleSql.Types;

public sealed class SqlBoolOf(bool val) : IQuery
{
    public string Raw()
    {
        return val ? "1" : "0";
    }
}