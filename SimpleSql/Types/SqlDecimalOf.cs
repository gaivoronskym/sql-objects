using System.Globalization;
using SimpleSql.Interfaces;

namespace SimpleSql.Types;

public sealed class SqlDecimalOf(decimal val) : IQuery
{
    public string Raw()
    {
        return val.ToString(CultureInfo.InvariantCulture);
    }
}