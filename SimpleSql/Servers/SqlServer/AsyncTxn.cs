using System.Data;
using SimpleSql.Interfaces;

namespace SimpleSql.Servers.SqlServer;

public class AsyncTxn : IAsyncTxn
{
    private readonly IDbConnection _connection;
    private readonly Func<Task> _action;
    private readonly IsolationLevel _isolationLevel;

    public AsyncTxn(IDbConnection connection, Func<Task> action)
        : this(connection, action, IsolationLevel.ReadCommitted)
    {
        
    }

    public AsyncTxn(IDbConnection connection, Func<Task> action, IsolationLevel isolationLevel)
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