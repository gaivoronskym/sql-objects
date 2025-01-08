using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

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