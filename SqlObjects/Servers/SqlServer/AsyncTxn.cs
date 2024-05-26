using System.Data;
using SqlObjects.Common;
using SqlObjects.Interfaces;
using Yaapii.Atoms;

namespace SqlObjects.Servers.SqlServer;

/// <summary>
/// Asynchronously runs SQL query in transaction
/// </summary>
/// <param name="connection"></param>
/// <param name="func"></param>
/// <param name="fallback"></param>
/// <param name="isolationLevel"></param>
public abstract class AsyncTxn<T>(IDbConnection connection, IFunc<Task<T>> func, IFunc<T> fallback, IQuery isolationLevel)
    : AsyncTxnEnvelop<T>(connection,
        func,
        fallback,
        isolationLevel,
        new RawSql("BEGIN TRANSACTION;"),
        new RawSql("COMMIT TRANSACTION;"),
        new RawSql("ROLLBACK TRANSACTION;"))
{
    protected override async Task<bool> HasTransactionAsync()
    {
        var openedTransactions = await new AsyncExecution<int>(
            Connection,
            new Select(
                "sys.sysprocesses",
                new Queries(
                    new RawSql("COUNT(*)")
                ),
                new Queries(
                    new Where(
                        new ExpressionOf("open_tran", true)
                    )
                )
            )
        ).InvokeAsync();

        return openedTransactions > 0;
    }

    /// <summary>
    /// Transaction with READ COMMITTED ISOLATION LEVEL
    /// </summary>
    /// <param name="connection"></param>
    /// <param name="func"></param>
    /// <param name="fallback"></param>
    public class ReadCommitted(IDbConnection connection, IFunc<Task<T>> func, IFunc<T> fallback) : AsyncTxn<T>(connection,
        func,
        fallback,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;"));

    /// <summary>
    /// Transaction with READ UNCOMMITTED ISOLATION LEVEL
    /// </summary>
    /// <param name="connection"></param>
    /// <param name="func"></param>
    /// <param name="fallback"></param>
    public class ReadUnCommitted(IDbConnection connection, IFunc<Task<T>> func, IFunc<T> fallback) : AsyncTxn<T>(connection,
        func,
        fallback,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;"));
}