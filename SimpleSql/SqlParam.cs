namespace SimpleSql;

public sealed class SqlParam(string key, IQuery query) : ISqlParam
{
    public string Key()
    {
        return key;
    }

    public IQuery Query()
    {
        return query;
    }
}