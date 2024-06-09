using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.SqlServer;

/// <summary>
/// FETCH NEXT [...] ROWS ONLY query
/// </summary>
/// <param name="rows"></param>
public sealed class Take(int rows) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "FETCH NEXT {0} ROWS ONLY",
            rows
        ).AsString();
    }
}