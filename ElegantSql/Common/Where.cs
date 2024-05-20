using ElegantSql.Interfaces;
using Yaapii.Atoms.Text;

namespace ElegantSql.Common;

/// <summary>
/// WHERE query
/// </summary>
/// <param name="query">expression</param>
public sealed class Where(IQuery query) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "WHERE {0}",
            query.Raw()
        ).AsString();
    }
}