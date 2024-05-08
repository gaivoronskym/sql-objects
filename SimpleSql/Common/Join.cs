using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public abstract class Join(string table, string first, string second, string type, IQuery query, string operation = "=")
    : IQuery
{
    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            new Formatted(
                "{0} JOIN {1} ON {2} {3} {4}",
                type,
                table,
                first,
                operation,
                second
            ),
            new TextOf(query.Raw)
        ).AsString();
    }
}