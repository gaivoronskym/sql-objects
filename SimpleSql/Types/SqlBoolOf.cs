using SimpleSql.Interfaces;

namespace SimpleSql.Types;

public sealed class SqlBoolOf : IQuery
{
    private readonly bool _val;

    public SqlBoolOf(bool val)
    {
        _val = val;
    }

    public string Raw()
    {
        return _val ? "1" : "0";
    }
}