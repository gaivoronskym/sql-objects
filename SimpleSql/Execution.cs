using System.Data;
using Dapper;
using SimpleSql.Interfaces;

namespace SimpleSql;

public class SyncExecution<T> : ISyncExecution<T>
{
    private readonly IDbConnection _connection;
    private readonly IQuery _query;
    private readonly int _timeout;

    public SyncExecution(IDbConnection connection, IQuery query)
        : this(connection, query, 30)
    {
        
    }
    
    public SyncExecution(IDbConnection connection, IQuery query, int timeout)
    {
        _connection = connection;
        _query = query;
        _timeout = timeout;
    }

    public T Invoke()
    {
        return _connection.ExecuteScalar<T>(
            sql: _query.Raw(),
            commandTimeout: _timeout
        )!;
    }
}