using SqlObjects.Common;
using Yaapii.Atoms.Text;

namespace SqlObjects.SqlServer;

/// <summary>
/// TOP [...] query
/// </summary>
/// <param name="rows"></param>
public sealed class Top(int rows) : QueryEnvelope(
    new Formatted(
        "TOP({0})",
        rows
    )
);