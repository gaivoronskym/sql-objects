using System.Data;
using Dapper;
using SqlObjects.Interfaces;
using Yaapii.Atoms;
using Yaapii.Atoms.Func;

namespace SqlObjects;

/// <summary>
/// Asynchronously runs SQL statement
/// </summary>
/// <param name="conn">database connection</param>
/// <param name="query">SQL query</param>
/// <param name="timeout">database command timeout</param>
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

/// <summary>
/// Asynchronously runs SQL statement
/// </summary>
public sealed class AsyncExecution : IAsyncExecution
{
    private readonly IFunc<Task> func;
    
    /// <param name="executions">List of executions</param>
    public AsyncExecution(params IAsyncExecution[] executions)
        : this(
            new FuncOf<Task>(
                () =>
                {
                    var tasks = new List<Task>();

                    foreach (var asyncExecution in executions)
                    {
                        tasks.Add(asyncExecution.InvokeAsync());
                    }
                    
                    return Task.WhenAll(tasks);
                }
            )
        )
    {
    }


    /// <param name="conn">database connection</param>
    /// <param name="query">sql query</param>
    public AsyncExecution(IDbConnection conn, IQuery query)
        : this(conn, query, 30)
    {
    }
    
    /// <param name="conn">database connection</param>
    /// <param name="query">sql query</param>
    /// <param name="timeout">database command timeout</param>
    public AsyncExecution(IDbConnection conn, IQuery query, int timeout)
        : this(
            new FuncOf<Task>(
                () => conn.ExecuteAsync(sql: query.Raw(), commandTimeout: timeout)
            )
        )
    {
    }

    private AsyncExecution(IFunc<Task> func)
    {
        this.func = func;
    }
    
    public Task InvokeAsync()
    {
        return func.Invoke();
    }
}