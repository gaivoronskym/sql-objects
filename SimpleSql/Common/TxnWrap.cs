using System.Data;
using SimpleSql.Interfaces;

namespace SimpleSql.Common;

public abstract class TxnWrap(IDbConnection connection, Action action, IQuery isolationLevel, IQuery begin,
        IQuery commit, IQuery rollback)
    : ITxn
{
    protected readonly IDbConnection Connection = connection;

    public void Invoke()
    {
        try
        {
            Begin();
        
            action();
        
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
            isolationLevel
        ).Invoke();
        
        new Execution<int>(
            Connection,
            begin
        ).Invoke();
    }
    
    private void Commit()
    {
        if (HasTransaction())
        {
            new Execution<int>(
                Connection,
                commit
            ).Invoke();
        }
    }
    
    private void Rollback()
    {
        if (HasTransaction())
        {
            new Execution<int>(
                Connection,
                rollback
            ).Invoke();
        }
    }
}