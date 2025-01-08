namespace SqlObjects.Types;

/// <summary>
/// Converts Int64 to SQL BIGINT
/// </summary>
/// <param name="val"></param>
public sealed class SqlBigintOf(long val) : IQuery
{
    public string Sql()
    {
        return val.ToString();
    }
}