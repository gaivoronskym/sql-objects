using ElegantSql.Interfaces;
using Yaapii.Atoms.Text;

namespace ElegantSql.Common;

/// <summary>
/// OR query
/// </summary>
/// <param name="expression">SQL expression</param>
public sealed class Or(IQuery expression) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "OR {0}",
            expression.Raw()
        ).AsString();
    }
}