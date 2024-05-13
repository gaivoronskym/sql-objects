﻿using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Types;

/// <summary>
/// Converts DateTime to SQL Date
/// </summary>
/// <param name="value"></param>
public sealed class SqlDateOf(DateTime value) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "'{0}'",
            value.ToString("yyyy-MM-dd")
        ).AsString();
    }
}