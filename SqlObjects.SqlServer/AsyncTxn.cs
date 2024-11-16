using SqlObjects.Common;
using SqlObjects.Interfaces;
using Yaapii.Atoms.List;

namespace SqlObjects.SqlServer;

/// <summary>
/// Asynchronously runs SQL query in transaction
/// </summary>
public abstract class AsyncTxn<T>: AsyncTxnEnvelop<T>
{
    private readonly IAsyncStatement stat;

    protected AsyncTxn(IAsyncStatement stat, IQuery isolationLevel)
        : base(
            stat,
            isolationLevel,
            new RawSql("BEGIN TRANSACTION;"),
            new RawSql("COMMIT TRANSACTION;"),
            new RawSql("ROLLBACK TRANSACTION;")
        )
    {
        this.stat = stat;
    }

    protected override async Task<bool> HasTransactionAsync()
    {
        var openedTransactions = await this.stat.ExecAsync<int>(
            new Select(
                new ListOf<IQuery>(
                    new RawSql("COUNT(*)")
                ),
                "sys.sysprocesses",
                new Where("open_tran", true)
            )
        );

        return openedTransactions > 0;
    }

    /// <summary>
    /// Transaction with READ COMMITTED ISOLATION LEVEL
    /// </summary>
    public sealed class ReadCommitted(IAsyncStatement stat) : AsyncTxn<T>(
        stat,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;"))
    {
    }

    /// <summary>
    /// Transaction with READ UNCOMMITTED ISOLATION LEVEL
    /// </summary>
    public sealed class ReadUnCommitted(IAsyncStatement stat) : AsyncTxn<T>(
        stat,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;"))
    {
    }

    /// <summary>
    /// Transaction with SERIALIZABLE ISOLATION LEVEL
    /// </summary>
    public sealed class Serializable(IAsyncStatement stat) : AsyncTxn<T>(
        stat,
        new RawSql("SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;"))
    {
    }
}