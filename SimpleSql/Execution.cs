using System.Data;
using Dapper;
using SimpleSql.Interfaces;

namespace SimpleSql;

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