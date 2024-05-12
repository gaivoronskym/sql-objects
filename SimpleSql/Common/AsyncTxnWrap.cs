using System.Data;
using SimpleSql.Interfaces;

namespace SimpleSql.Common;

public abstract class AsyncTxnWrap(IDbConnection connection, Func<Task> action, IQuery isolationLevel, IQuery begin,
        IQuery commit, IQuery rollback)
    : IAsyncTxn
{
    protected readonly IDbConnection Connection = connection;

    public async Task Invoke()
    {
        try
        {
            await BeginAsync();

            await action();

            await CommitAsync();
        }
        catch (Exception e)
        {
            await RollbackAsync();
            Console.WriteLine(e);
        }
    }

    protected abstract Task<bool> HasTransactionAsync();

    private async Task BeginAsync()
    {
        await new AsyncExecution<int>(
            Connection,
            isolationLevel
        ).InvokeAsync();

        await new AsyncExecution<int>(
            Connection,
            begin
        ).InvokeAsync();
    }

    private async Task CommitAsync()
    {
        if (await HasTransactionAsync())
        {
            await new AsyncExecution<int>(
                Connection,
                commit
            ).InvokeAsync();
        }
    }

    private async Task RollbackAsync()
    {
        if (await HasTransactionAsync())
        {
            await new AsyncExecution<int>(
                Connection,
                rollback
            ).InvokeAsync();
        }
    }
}