using System.Data;
using SqlObjects.Interfaces;
using Yaapii.Atoms;

namespace SqlObjects.Common;

/// <summary>
/// Transaction wrapper
/// </summary>
/// <param name="connection">database connection</param>
/// <param name="func">action to execute</param>
/// <param name="fallback"></param>
/// <param name="isolationLevel"></param>
/// <param name="begin"></param>
/// <param name="commit"></param>
/// <param name="rollback"></param>
public abstract class TxnEnvelop<T>(IDbConnection connection, IFunc<T> func, IFunc<T> fallback, IQuery isolationLevel, IQuery begin,
        IQuery commit, IQuery rollback)
    : ITxn<T>
{
    protected readonly IDbConnection Connection = connection;

    public T Invoke()
    {
        try
        {
            Begin();
        
            var res = func.Invoke();
        
            Commit();

            return res;
        }
        catch (Exception e)
        {
            Rollback();
            Console.WriteLine(e);
            return fallback.Invoke();
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