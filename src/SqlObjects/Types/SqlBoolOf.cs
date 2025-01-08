namespace SqlObjects.Types;

/// <summary>
/// Converts Boolean to SQL BIT
/// </summary>
/// <param name="val"></param>
public sealed class SqlBoolOf(bool val) : IQuery
{
    public string Sql()
    {
        return val ? "1" : "0";
    }
}