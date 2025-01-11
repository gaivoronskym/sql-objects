﻿using SqlObjects.Common;
using Yaapii.Atoms.Text;

namespace SqlObjects.Types;

/// <summary>
/// Converts DateTime to SQL Date
/// </summary>
/// <param name="value"></param>
public sealed class SqlDateOf(DateTime value) : QueryEnvelope(new Formatted("'{0}'", value.ToString("yyyy-MM-dd")));