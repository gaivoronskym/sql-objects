using Yaapii.Atoms.Text;

namespace SimpleSql.Types;

public class SqlDateOf : IQuery
{
    private readonly DateTime _value;

    public SqlDateOf(DateTime value)
    {
        _value = value;
    }

    public string Raw()
    {
        return new Formatted(
            "'{0}'",
            _value.ToString("yyyy-MM-dd")
        ).AsString();
    }
}