using System.Data;
using Dapper;
using SimpleSql.Interfaces;

namespace SimpleSql;

public sealed class AsyncExecution<T>(IDbConnection connection, IQuery query, int timeout) : IAsyncExecution<T>
{
    public AsyncExecution(IDbConnection connection, IQuery query)
        : this(connection, query, 30)
    {
        
    }

    public Task<T> Invoke()
    {
        return connection.ExecuteScalarAsync<T>(
            sql: query.Raw(),
            commandTimeout: timeout
        )!;
    }
}
