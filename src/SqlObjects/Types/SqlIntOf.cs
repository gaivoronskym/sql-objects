using SqlObjects.Common;

namespace SqlObjects.Types;

/// <summary>
/// Converts Int32 to SQL INT
/// </summary>
/// <param name="val"></param>
public sealed class SqlIntOf(int val) : QueryEnvelope(val.ToString());