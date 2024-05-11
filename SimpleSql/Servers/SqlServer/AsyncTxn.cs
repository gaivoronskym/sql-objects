using System.Data;
using SimpleSql.Interfaces;

namespace SimpleSql.Servers.SqlServer;

public sealed class AsyncTxn(IDbConnection connection, Func<Task> action, IsolationLevel isolationLevel)
    : IAsyncTxn
{
    public AsyncTxn(IDbConnection connection, Func<Task> action)
        : this(connection, action, IsolationLevel.ReadCommitted)
    {
        
    }

    public async Task Invoke()
    {
        using (var scope = connection.BeginTransaction(isolationLevel))
        {
            await action();
            scope.Commit();
        }
    }
}