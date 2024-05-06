namespace SimpleSql;

public sealed class Insert : IQuery
{
    private readonly string _table;

    public Insert(string table)
    {
        _table = table;
    }

    public string Raw()
    {
        throw new NotImplementedException();
    }
}