using SqlObjects.Common;
using SqlObjects.Interfaces;
using Yaapii.Atoms.List;

namespace SqlObjects.SqlServer;

/// <summary>
/// Runs SQL query in transaction
/// </summary>
public abstract class Txn<T>: TxnEnvelop<T>
{
    private readonly IStatement stat;

    protected Txn(IStatement stat, IQuery isolationLevel)
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

    protected override bool HasTransaction()
    {
        var openedTransactions = this.stat.Exec<int>(
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
    public sealed class ReadCommitted(IStatement stat) : Txn<T>(
        stat,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;"))
    {
    }

    /// <summary>
    /// Transaction with READ UNCOMMITTED ISOLATION LEVEL
    /// </summary>
    public sealed class ReadUnCommitted(IStatement stat) : Txn<T>(
        stat,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;"))
    {
    }

    /// <summary>
    /// Transaction with SERIALIZABLE ISOLATION LEVEL
    /// </summary>
    public sealed class Serializable(IStatement stat) : Txn<T>(
        stat,
        new RawSql("SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;"))
    {
    }
}