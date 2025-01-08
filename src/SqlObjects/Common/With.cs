using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// Common table expression WITH [name_of_expression] AS (...)
/// </summary>
/// <param name="name">name of common table expression</param>
/// <param name="expressions">list of expressions</param>
public sealed class With(string name, params IQuery[] expressions) : QueryEnvelope(
    new Formatted(
        "WITH {0} AS ({1} {2} {3})",
        new TextOf(name),
        new TextOf(Environment.NewLine),
        new Joined(Environment.NewLine, expressions.Select(q => q.Sql())),
        new TextOf(Environment.NewLine)
    )
);