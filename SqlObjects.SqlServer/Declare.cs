using SqlObjects.Common;
using Yaapii.Atoms.Text;

namespace SqlObjects.SqlServer;

/// <summary>
/// DECLARE [name] [type]; query
/// </summary>
/// <param name="name">name of object</param>
/// <param name="type">type of object</param>
public sealed class Declare(string name, string type) : QueryEnvelope(
    new Formatted(
        "DECLARE @{0} {1};",
        name,
        type
    )
);