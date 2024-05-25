﻿using ElegantSql.Interfaces;
using ElegantSql.Types;
using Yaapii.Atoms.Text;

namespace ElegantSql.Common;

/// <summary>
/// IS NULL query
/// </summary>
/// <param name="expression">SQL expression</param>
public sealed class IsNull(IQuery expression) : IQuery
{
    public IsNull(string expression)
        : this(new RawSql(expression))
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "{0} IS {1}",
            expression.Raw(),
            new SqlNull().Raw()
        ).AsString();
    }
}