using SqlObjects.Interfaces;

namespace SqlObjects.Common;

/// <summary>
/// Transaction wrapper
/// </summary>
public abstract class TxnEnvelop<T> : ITxn<T>
{
    private readonly IStatement stat;
    private readonly IQuery isolationLevel;
    private readonly IQuery begin;
    private readonly IQuery commit;
    private readonly IQuery rollback;

    protected TxnEnvelop(IStatement stat, IQuery isolationLevel, IQuery begin, IQuery commit, IQuery rollback)
    {
        this.stat = stat;
        this.isolationLevel = isolationLevel;
        this.begin = begin;
        this.commit = commit;
        this.rollback = rollback;
    }

    public T Invoke(Func<T> func)
    {
        try
        {
            Begin();
            var res = func.Invoke();
            Commit();
            return res;
        }
        catch (Exception ex)
        {
            Rollback();
            Console.WriteLine(ex);
            throw;
        }
    }

    protected abstract bool HasTransaction();

    private void Begin()
    {
        this.stat.Exec(
            new QueryOf(
                new Queries(
                    isolationLevel,
                    begin
                )
            )
        );
    }
    
    private void Commit()
    {
        if (HasTransaction())
        {
            this.stat.Exec(commit);
        }
    }
    
    private void Rollback()
    {
        if (HasTransaction())
        {
            this.stat.Exec(rollback);
        }
    }
}