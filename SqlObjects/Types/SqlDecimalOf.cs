﻿using System.Globalization;
using SqlObjects.Interfaces;

namespace SqlObjects.Types;

/// <summary>
/// Converts Decimal to SQL DECIMAL
/// </summary>
/// <param name="val"></param>
public sealed class SqlDecimalOf(decimal val) : IQuery
{
    public string Raw()
    {
        return val.ToString(CultureInfo.InvariantCulture);
    }
}