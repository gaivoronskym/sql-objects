using System.Globalization;

namespace SimpleSql.Types;

public sealed class SqlDecimalOf : IQuery
{
    private readonly decimal _val;

    public SqlDecimalOf(decimal val)
    {
        _val = val;
    }

    public string Raw()
    {
        return _val.ToString(CultureInfo.InvariantCulture);
    }
}