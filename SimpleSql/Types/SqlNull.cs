using SimpleSql.Interfaces;

namespace SimpleSql.Types;

/// <summary>
/// Returns SQL NULL
/// </summary>
public sealed class SqlNull : IQuery
{
    public string Raw()
    {
        return "NULL";
    }
}