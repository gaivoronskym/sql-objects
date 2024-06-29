using SqlObjects.Interfaces;
using SqlObjects.Scalar;
using SqlObjects.Text;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

public abstract class Join(string table, string first, string second, string type, IQuery query, string operation = "=")
    : IQuery
{
    public string Raw()
    {
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
                new StringFilled(query.Raw),
                new Formatted(
                    "{0}{1}",
                    Environment.NewLine,
                    query.Raw()
                )
            )
        ).AsString();
    }
}