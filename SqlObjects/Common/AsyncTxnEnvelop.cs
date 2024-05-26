using System.Data;
using SqlObjects.Interfaces;
using Yaapii.Atoms;

namespace SqlObjects.Common;

public abstract class AsyncTxnEnvelop<T>(IDbConnection connection, IFunc<Task<T>> func, IFunc<T> fallback, IQuery isolationLevel, IQuery begin,
        IQuery commit, IQuery rollback)
    : IAsyncTxn<T>
{
    protected readonly IDbConnection Connection = connection;

    public async Task<T> Invoke()
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
            return fallback.Invoke();
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