using SqlObjects.Common;
using Yaapii.Atoms.Text;

namespace SqlObjects.Types;

/// <summary>
/// Converts String to SQL literal
/// </summary>
/// <param name="val"></param>
public sealed class SqlStringOf(string val) : QueryEnvelope(() => new Formatted("'{0}'", val.Replace("'", "''")));