using System.Data;
using Dapper;
using SqlObjects.Interfaces;

namespace SqlObjects;

/// <summary>
/// Asynchronously runs SQL statement
/// </summary>
/// <param name="conn">database connection</param>
/// <param name="query">SQL query</param>
/// <param name="timeout">command timeout</param>
/// <typeparam name="T">type of result</typeparam>
public sealed class AsyncExecution<T>(IDbConnection conn, IQuery query, int timeout) : IAsyncExecution<T>
{
    public AsyncExecution(IDbConnection conn, IQuery query)
        : this(conn, query, 30)
    {
        
    }

    public Task<T> InvokeAsync()
    {
        return conn.ExecuteScalarAsync<T>(
            sql: query.Raw(),
            commandTimeout: timeout
        )!;
    }
}
