using System.Data;
using Dapper;
using SimpleSql.Interfaces;

namespace SimpleSql;

public class Execution<T> : IExecution<T>
{
    private readonly IDbConnection _connection;
    private readonly IQuery _query;
    private readonly int _timeout;

    public Execution(IDbConnection connection, IQuery query)
        : this(connection, query, 30)
    {
        
    }
    
    public Execution(IDbConnection connection, IQuery query, int timeout)
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