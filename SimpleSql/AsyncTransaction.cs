using System.Data;
using SimpleSql.Interfaces;

namespace SimpleSql;

public class AsyncTransaction : IAsyncTransaction
{
    private readonly IDbConnection _connection;
    private readonly Func<Task> _action;
    private readonly IsolationLevel _isolationLevel;

    public AsyncTransaction(IDbConnection connection, Func<Task> action)
        : this(connection, action, IsolationLevel.ReadCommitted)
    {
        
    }

    public AsyncTransaction(IDbConnection connection, Func<Task> action, IsolationLevel isolationLevel)
    {
        _connection = connection;
        _action = action;
        _isolationLevel = isolationLevel;
    }

    public async Task Invoke()
    {
        using (var scope = _connection.BeginTransaction(_isolationLevel))
        {
            await _action();
            scope.Commit();
        }
    }
}