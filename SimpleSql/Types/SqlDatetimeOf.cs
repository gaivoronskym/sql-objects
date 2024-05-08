using Yaapii.Atoms.Text;

namespace SimpleSql.Types;

public class SqlDatetimeOf : IQuery
{
    private readonly DateTime _value;

    public SqlDatetimeOf(DateTime value)
    {
        _value = value;
    }

    public string Raw()
    {
        return new Formatted(
            "'{0}'",
            _value.ToString("yyyy-MM-dd HH:mm:ss:fff")
        ).AsString();
    }
}