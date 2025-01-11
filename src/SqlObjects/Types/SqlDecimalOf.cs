using System.Globalization;
using SqlObjects.Common;

namespace SqlObjects.Types;

/// <summary>
/// Converts Decimal to SQL DECIMAL
/// </summary>
/// <param name="val"></param>
public sealed class SqlDecimalOf(decimal val) : QueryEnvelope(val.ToString(CultureInfo.InvariantCulture));