using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Types;

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