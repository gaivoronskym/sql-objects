using SqlObjects.Common;
using Yaapii.Atoms.Text;

namespace SqlObjects.Types;

/// <summary>
/// Converts DateTime to SQL DATETIME2
/// </summary>
/// <param name="value"></param>
public sealed class SqlDatetimeOf(DateTime value) : QueryEnvelope(new Formatted("'{0}'", value.ToString("yyyy-MM-dd HH:mm:ss:fff")));