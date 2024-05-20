using System.Data;
using Dapper;
using ElegantSql.Interfaces;

namespace ElegantSql;

/// <summary>
/// Runs SQL statement
/// </summary>
/// <param name="connection">database connection</param>
/// <param name="query">SQL query</param>
/// <param name="timeout">command timeout</param>
/// <typeparam name="T">type of result</typeparam>
public sealed class Execution<T>(IDbConnection connection, IQuery query, int timeout) : IExecution<T>
{
    public Execution(IDbConnection connection, IQuery query)
        : this(connection, query, 30)
    {
        
    }

    public T Invoke()
    {
        return connection.ExecuteScalar<T>(
            sql: query.Raw(),
            commandTimeout: timeout
        )!;
    }
}