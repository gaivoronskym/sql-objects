using System.Data;
using Dapper;
using SqlObjects.Interfaces;

namespace SqlObjects;

/// <summary>
/// Asynchronously runs SQL statement
/// </summary>
public sealed class AsyncStatement : IAsyncStatement
{
    private readonly IDbConnection conn;
    private readonly int timeout;

    /// <param name="conn">database connection</param>
    public AsyncStatement(IDbConnection conn)
        : this(conn, 30)
    {
    }
    
    /// <param name="conn">database connection</param>
    /// <param name="timeout">database command timeout</param>
    public AsyncStatement(IDbConnection conn, int timeout)

    {
        this.conn = conn;
        this.timeout = timeout;
    }

    public Task<T> ExecAsync<T>(IQuery query)
    {
        return this.conn.ExecuteScalarAsync<T>(
            sql: query.Raw(),
            commandTimeout: timeout
        )!;
    }

    public Task ExecAsync(IQuery query)
    {
        return this.conn.ExecuteAsync(sql: query.Raw(), commandTimeout: this.timeout);
    }
}