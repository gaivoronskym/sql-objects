﻿using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Servers.SqlServer;

/// <summary>
/// HAVING query
/// </summary>
/// <param name="expressions"></param>
public sealed class Having(IEnumerable<IQuery> expressions) : IQuery
{
    public Having(params string[] raw)
        : this(raw.Select(r => new RawSql(r)))
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "HAVING {0}",
            new Joined(", ", expressions.Select(q => q.Raw()))
        ).AsString();
    }
}