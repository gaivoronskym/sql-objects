using System.Data;
using SqlObjects.Interfaces;

namespace SqlObjects.Common;

public abstract class AsyncTxnEnvelop<T>(IDbConnection conn, IQuery isolationLevel, IQuery begin, IQuery commit, IQuery rollback)
    : IAsyncTxn<T>
{
    protected readonly IDbConnection Conn = conn;

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
        return new AsyncExecution(
            Conn,
            new QueryOf(
                new Queries(
                    isolationLevel,
                    begin
                )
            )
        ).InvokeAsync();
    }

    private async Task CommitAsync()
    {
        if (await HasTransactionAsync())
        {
            await new AsyncExecution(
                Conn,
                commit
            ).InvokeAsync();
        }
    }

    private async Task RollbackAsync()
    {
        if (await HasTransactionAsync())
        {
            await new AsyncExecution(
                Conn,
                rollback
            ).InvokeAsync();
        }
    }
}