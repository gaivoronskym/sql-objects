using System.Data;
using SimpleSql.Interfaces;

namespace SimpleSql.Common;

public abstract class TxnWrap : ITxn
{
    protected readonly IDbConnection Connection;
    private readonly Action _action;
    private readonly IQuery _isolationLevel;
    private readonly IQuery _begin;
    private readonly IQuery _commit;
    private readonly IQuery _rollback;
    
    protected TxnWrap(IDbConnection connection, Action action, IQuery isolationLevel, IQuery begin, IQuery commit, IQuery rollback)
    {
        Connection = connection;
        _action = action;
        _isolationLevel = isolationLevel;
        _begin = begin;
        _commit = commit;
        _rollback = rollback;
    }
    
    public void Invoke()
    {
        try
        {
            Begin();
        
            _action();
        
            Commit();
        }
        catch (Exception e)
        {
            Rollback();
            Console.WriteLine(e);
        }
    }

    protected abstract bool HasTransaction();

    private void Begin()
    {
        new Execution<int>(
            Connection,
            _isolationLevel
        ).Invoke();
        
        new Execution<int>(
            Connection,
            _begin
        ).Invoke();
    }
    
    private void Commit()
    {
        if (HasTransaction())
        {
            new Execution<int>(
                Connection,
                _commit
            ).Invoke();
        }
    }
    
    private void Rollback()
    {
        if (HasTransaction())
        {
            new Execution<int>(
                Connection,
                _rollback
            ).Invoke();
        }
    }
}