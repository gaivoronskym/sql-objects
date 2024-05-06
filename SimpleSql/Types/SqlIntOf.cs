namespace SimpleSql.Types;

public sealed class SqlIntOf : IQuery
{
    private readonly int _val;

    public SqlIntOf(int val)
    {
        _val = val;
    }

    public string Raw()
    {
        return _val.ToString();
    }
}