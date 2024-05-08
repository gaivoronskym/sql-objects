using System.Data;
using Dapper;
using SimpleSql.Interfaces;

namespace SimpleSql;

public class AsyncExecution<T> : IAsyncExecution<T>
{
    private readonly IDbConnection _connection;
    private readonly IQuery _query;
    private readonly int _timeout;

    public AsyncExecution(IDbConnection connection, IQuery query)
        : this(connection, query, 30)
    {
        
    }
    
    public AsyncExecution(IDbConnection connection, IQuery query, int timeout)
    {
        _connection = connection;
        _query = query;
        _timeout = timeout;
    }
    
    public Task<T> Invoke()
    {
        return _connection.ExecuteScalarAsync<T>(
            sql: _query.Raw(),
            commandTimeout: _timeout
        )!;
    }
}
