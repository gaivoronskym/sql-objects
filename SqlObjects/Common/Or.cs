using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

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