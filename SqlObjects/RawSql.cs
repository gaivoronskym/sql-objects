﻿using SqlObjects.Interfaces;
using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SqlObjects;

/// <summary>
/// SQL query
/// </summary>
/// <param name="val"></param>
public sealed class RawSql(IText val) : IQuery
{
    public RawSql(string val)
        : this(new TextOf(val))
    {
    }

    public string Raw()
    {
        return val.AsString();
    }
}