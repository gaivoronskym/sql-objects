using SqlObjects.Interfaces;

namespace SqlObjects.Common;

/// <summary>
/// Transaction wrapper
/// </summary>
public abstract class TxnEnvelop : ITxn
{
    private readonly IConsole con;
    private readonly IQuery isolationLevel;
    private readonly IQuery begin;
    private readonly IQuery commit;
    private readonly IQuery rollback;

    protected TxnEnvelop(IConsole con, IQuery isolationLevel, IQuery begin, IQuery commit, IQuery rollback)
    {
        this.con = con;
        this.isolationLevel = isolationLevel;
        this.begin = begin;
        this.commit = commit;
        this.rollback = rollback;
    }

    public T Invoke<T>(Func<T> func)
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
            System.Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<T> Invoke<T>(Func<Task<T>> func)
    {
        try
        {
            Begin();
            var res = await func.Invoke();
            Commit();
            return res;
        }
        catch (Exception ex)
        {
            Rollback();
            System.Console.WriteLine(ex);
            throw;
        }
    }

    protected abstract bool HasTransaction();

    public void Begin()
    {
        this.con.Exec(
            new QueryOf(
                new Queries(
                    isolationLevel,
                    begin
                )
            )
        );
    }

    public void Commit()
    {
        if (HasTransaction())
        {
            this.con.Exec(commit);
        }
    }

    public void Rollback()
    {
        if (HasTransaction())
        {
            this.con.Exec(rollback);
        }
    }
}