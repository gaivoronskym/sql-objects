﻿using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Types;

/// <summary>
/// Converts String to SQL literal
/// </summary>
/// <param name="val"></param>
public sealed class SqlStringOf(string val) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "'{0}'",
            new Replaced(
                new TextOf(val),
                "'",
                "''"
            )
        ).AsString();
    }
}