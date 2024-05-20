using ElegantSql.Interfaces;
using Yaapii.Atoms.Text;

namespace ElegantSql.Types;

/// <summary>
/// Converts DateTime to SQL DATETIME2
/// </summary>
/// <param name="value"></param>
public sealed class SqlDatetimeOf(DateTime value) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "'{0}'",
            value.ToString("yyyy-MM-dd HH:mm:ss:fff")
        ).AsString();
    }
}