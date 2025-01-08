namespace SqlObjects.Types;

/// <summary>
/// Returns SQL NULL
/// </summary>
public sealed class SqlNull : IQuery
{
    public string Sql()
    {
        return "NULL";
    }
}