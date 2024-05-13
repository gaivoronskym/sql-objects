using System.Data;
using SimpleSql.Common;
using SimpleSql.Interfaces;

namespace SimpleSql.Servers.SqlServer;

/// <summary>
/// Asynchronously runs SQL query in transaction
/// </summary>
/// <param name="connection"></param>
/// <param name="action"></param>
/// <param name="isolationLevel"></param>
public abstract class AsyncTxn(IDbConnection connection, Func<Task> action, IQuery isolationLevel)
    : AsyncTxnWrap(connection,
        action,
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
    /// <param name="action"></param>
    public class ReadCommitted(IDbConnection connection, Func<Task> action) : AsyncTxn(connection,
        action,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;"));

    /// <summary>
    /// Transaction with READ UNCOMMITTED ISOLATION LEVEL
    /// </summary>
    /// <param name="connection"></param>
    /// <param name="action"></param>
    public class ReadUnCommitted(IDbConnection connection, Func<Task> action) : AsyncTxn(connection,
        action,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;"));
}