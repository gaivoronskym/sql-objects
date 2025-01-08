using System.Globalization;

namespace SqlObjects.Types;

/// <summary>
/// Converts Decimal to SQL DECIMAL
/// </summary>
/// <param name="val"></param>
public sealed class SqlDecimalOf(decimal val) : IQuery
{
    public string Sql()
    {
        return val.ToString(CultureInfo.InvariantCulture);
    }
}