using System.Globalization;
using ElegantSql.Interfaces;

namespace ElegantSql.Types;

/// <summary>
/// Converts Decimal to SQL DECIMAL
/// </summary>
/// <param name="val"></param>
public sealed class SqlDecimalOf(decimal val) : IQuery
{
    public string Raw()
    {
        return val.ToString(CultureInfo.InvariantCulture);
    }
}