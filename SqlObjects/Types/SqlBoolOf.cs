using SqlObjects.Interfaces;

namespace SqlObjects.Types;

/// <summary>
/// Converts Boolean to SQL BIT
/// </summary>
/// <param name="val"></param>
public sealed class SqlBoolOf(bool val) : IQuery
{
    public string Raw()
    {
        return val ? "1" : "0";
    }
}