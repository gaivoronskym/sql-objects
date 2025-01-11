using SqlObjects.Common;

namespace SqlObjects.Types;

/// <summary>
/// Converts Boolean to SQL BIT
/// </summary>
/// <param name="val"></param>
public sealed class SqlBoolOf(bool val) : QueryEnvelope(val ? "1" : "0");