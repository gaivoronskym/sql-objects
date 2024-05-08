using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Types;

public sealed class SqlStringOf : IQuery
{
    private readonly string _val;

    public SqlStringOf(string val)
    {
        _val = val;
    }

    public string Raw()
    {
        return new Formatted(
            "'{0}'",
            new Replaced(
                new TextOf(_val),
                "'",
                "''"
            )
        ).AsString();
    }
}