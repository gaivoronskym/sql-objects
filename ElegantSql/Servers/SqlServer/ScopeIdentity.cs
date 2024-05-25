﻿using ElegantSql.Interfaces;

namespace ElegantSql.Servers.SqlServer;

/// <summary>
/// SCOPE_IDENTITY() function
/// </summary>
public sealed class ScopeIdentity : IQuery
{
    public string Raw()
    {
        return "SELECT scope_identity() as Id;";
    }
}