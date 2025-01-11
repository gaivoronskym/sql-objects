using SqlObjects.Common;

namespace SqlObjects.Types;

/// <summary>
/// Converts Int64 to SQL BIGINT
/// </summary>
/// <param name="val"></param>
public sealed class SqlBigintOf(long val) : QueryEnvelope(val.ToString());