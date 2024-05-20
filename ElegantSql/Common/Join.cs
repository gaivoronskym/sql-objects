using ElegantSql.Interfaces;
using Yaapii.Atoms.Text;

namespace ElegantSql.Common;

public abstract class Join(string table, string first, string second, string type, IQuery query, string operation = "=")
    : IQuery
{
    public string Raw()
    {
        var queryRaw = query.Raw();

        return new Joined(
            "",
            new Formatted(
                "{0} JOIN {1} ON {2} {3} {4}",
                type,
                table,
                first,
                operation,
                second
            ),
            new TextIf(
                !string.IsNullOrEmpty(queryRaw),
                new Formatted(
                    "{0}{1}",
                    Environment.NewLine,
                    queryRaw
                )
            )
        ).AsString();
    }
}