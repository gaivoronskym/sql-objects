using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// FETCH NEXT [...] ROWS ONLY query
/// </summary>
/// <param name="rows"></param>
public sealed class Take(int rows) : QueryEnvelope(
    new Formatted(
        "FETCH NEXT {0} ROWS ONLY",
        rows
    )
);