using SqlObjects.Common;

namespace SqlObjects.Types;

/// <summary>
/// Returns SQL NULL
/// </summary>
public sealed class SqlNull() : QueryEnvelope("NULL");