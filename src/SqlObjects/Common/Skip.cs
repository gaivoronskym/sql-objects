using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// OFFSET [...] ROWS query
/// </summary>
/// <param name="rows"></param>
public sealed class Skip(int rows) : QueryEnvelope(
    new Formatted(
        "OFFSET {0} ROWS",
        rows
    )
);