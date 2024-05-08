using SimpleSql.Interfaces;

namespace SimpleSql.Types;

public sealed class SqlBigintOf : IQuery
{
    private readonly long _val;

    public SqlBigintOf(long val)
    {
        _val = val;
    }

    public string Raw()
    {
        return _val.ToString();
    }
}