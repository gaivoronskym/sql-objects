using System.Data;
using Dapper;
using SqlObjects.Interfaces;
using Yaapii.Atoms;
using Yaapii.Atoms.Func;

namespace SqlObjects;

/// <summary>
/// Runs SQL statement
/// </summary>
/// <param name="conn">database connection</param>
/// <param name="query">SQL query</param>
/// <param name="timeout">command timeout</param>
/// <typeparam name="T">type of result</typeparam>
public sealed class Statement<T>(IDbConnection conn, IQuery query, int timeout) : IStatement<T>
{
    public Statement(IDbConnection conn, IQuery query)
        : this(conn, query, 30)
    {
    }

    public T Exec()
    {
        return conn.ExecuteScalar<T>(
            sql: query.Raw(),
            commandTimeout: timeout
        )!;
    }
}

/// <summary>
/// Runs SQL statement
/// </summary>
public sealed class Statement : IStatement
{
    private readonly IAction action;

    /// <summary>
    /// List of executions to bulk invoke
    /// </summary>
    /// <param name="executions"></param>
    public Statement(params IStatement[] executions)
        : this(
            new ActionOf(
                () =>
                {
                    foreach (var execution in executions)
                    {
                        execution.Exec();
                    }
                }
            )
        )
    {
    }
    
    public Statement(IDbConnection conn, IQuery query)
        : this(conn, query, 30)
    {
    }

    public Statement(IDbConnection conn, IQuery query, int timeout)
        : this(
            new ActionOf(
                () => conn.Execute(sql: query.Raw(), commandTimeout: timeout)
            )
        )
    {
    }

    private Statement(IAction action)
    {
        this.action = action;
    }
    
    public void Exec()
    {
        action.Invoke();
    }
}