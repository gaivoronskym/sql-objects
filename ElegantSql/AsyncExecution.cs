using System.Data;
using Dapper;
using ElegantSql.Interfaces;

namespace ElegantSql;

/// <summary>
/// Asynchronously runs SQL statement
/// </summary>
/// <param name="connection">database connection</param>
/// <param name="query">SQL query</param>
/// <param name="timeout">command timeout</param>
/// <typeparam name="T">type of result</typeparam>
public sealed class AsyncExecution<T>(IDbConnection connection, IQuery query, int timeout) : IAsyncExecution<T>
{
    public AsyncExecution(IDbConnection connection, IQuery query)
        : this(connection, query, 30)
    {
        
    }

    public Task<T> InvokeAsync()
    {
        return connection.ExecuteScalarAsync<T>(
            sql: query.Raw(),
            commandTimeout: timeout
        )!;
    }
}
