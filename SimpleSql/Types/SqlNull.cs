using SimpleSql.Interfaces;

namespace SimpleSql.Types;

public sealed class SqlNull : IQuery
{
    public string Raw()
    {
        return "NULL";
    }
}