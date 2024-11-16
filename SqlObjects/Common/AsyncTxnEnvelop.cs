using SqlObjects.Interfaces;

namespace SqlObjects.Common;

public abstract class AsyncTxnEnvelop<T> : IAsyncTxn<T>
{
    private readonly IAsyncStatement stat;
    private readonly IQuery isolationLevel;
    private readonly IQuery begin;
    private readonly IQuery commit;
    private readonly IQuery rollback;

    protected AsyncTxnEnvelop(IAsyncStatement stat, IQuery isolationLevel, IQuery begin, IQuery commit, IQuery rollback)
    {
        this.stat = stat;
        this.isolationLevel = isolationLevel;
        this.begin = begin;
        this.commit = commit;
        this.rollback = rollback;
    }

    public async Task<T> Invoke(Func<Task<T>> func)
    {
        try
        {
            await BeginAsync();
            var res = await func.Invoke();
            await CommitAsync();
            return res;
        }
        catch (Exception e)
        {
            await RollbackAsync();
            Console.WriteLine(e);
            throw;
        }
    }

    protected abstract Task<bool> HasTransactionAsync();

    private Task BeginAsync()
    {
        return this.stat.ExecAsync(
            new QueryOf(
                new Queries(
                    isolationLevel,
                    begin
                )
            )
        );
    }

    private async Task CommitAsync()
    {
        if (await HasTransactionAsync())
        {
            await this.stat.ExecAsync(commit);
        }
    }

    private async Task RollbackAsync()
    {
        if (await HasTransactionAsync())
        {
            await this.stat.ExecAsync(rollback);
        }
    }
}