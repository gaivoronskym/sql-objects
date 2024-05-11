using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Types;

public sealed class SqlDateOf(DateTime value) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "'{0}'",
            value.ToString("yyyy-MM-dd")
        ).AsString();
    }
}