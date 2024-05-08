using System.Data;
using SimpleSql.Interfaces;

namespace SimpleSql;

public class SyncTransaction : ISyncTransaction
{
    private readonly IDbConnection _connection;
    private readonly Action _action;
    private readonly IsolationLevel _isolationLevel;

    public SyncTransaction(IDbConnection connection, Action action)
        : this(connection, action, IsolationLevel.ReadCommitted)
    {
        
    }

    public SyncTransaction(IDbConnection connection, Action action, IsolationLevel isolationLevel)
    {
        _connection = connection;
        _action = action;
        _isolationLevel = isolationLevel;
    }

    public void Invoke()
    {
        using (var scope = _connection.BeginTransaction(_isolationLevel))
        {
            _action();
            
            scope.Commit();
        }
    }
}