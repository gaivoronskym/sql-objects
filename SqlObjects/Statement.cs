using System.Data;
using Dapper;
using SqlObjects.Interfaces;

namespace SqlObjects;

/// <summary>
/// Runs SQL statement
/// </summary>
public sealed class Statement : IStatement
{
    private readonly IDbConnection conn;
    private readonly int timeout;
    
    public Statement(IDbConnection conn)
        : this(conn, 30)
    {
    }

    public Statement(IDbConnection conn, int timeout)
    {
        this.conn = conn;
        this.timeout = timeout;
    }

    public T Exec<T>(IQuery query)
    {
        return conn.ExecuteScalar<T>(
            sql: query.Raw(),
            commandTimeout: timeout
        )!;
    }

    public void Exec(IQuery query)
    {
        conn.Execute(sql: query.Raw(), commandTimeout: timeout);
    }
}