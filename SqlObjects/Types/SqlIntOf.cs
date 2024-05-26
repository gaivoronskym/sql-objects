using SqlObjects.Interfaces;

namespace SqlObjects.Types;

/// <summary>
/// Converts Int32 to SQL INT
/// </summary>
/// <param name="val"></param>
public sealed class SqlIntOf(int val) : IQuery
{
    public string Raw()
    {
        return val.ToString();
    }
}