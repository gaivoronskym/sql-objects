﻿using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

/// <summary>
/// AND query
/// </summary>
/// <param name="query">expression</param>
public sealed class And(IQuery query) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "AND {0}",
            query.Raw()
        ).AsString();
    }
}