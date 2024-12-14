using SqlObjects.Common;
using SqlObjects.Interfaces;
using Yaapii.Atoms.List;

namespace SqlObjects.SqlServer;

/// <summary>
/// Runs SQL query in transaction
/// </summary>
public abstract class Txn: TxnEnvelop
{
    private readonly IConsole iConsole;

    protected Txn(IConsole con, IQuery isolationLevel)
        : base(
            con,
            isolationLevel,
            new RawSql("BEGIN TRANSACTION;"),
            new RawSql("COMMIT TRANSACTION;"),
            new RawSql("ROLLBACK TRANSACTION;")
        )
    {
        this.iConsole = iConsole;
    }

    protected override bool HasTransaction()
    {
        var openedTransactions = this.iConsole.Exec(
            new Select(
                "*",
                "sys.sysprocesses",
                new Where("open_tran", true)
            )
        );

        return openedTransactions.Any();
    }

    /// <summary>
    /// Transaction with READ COMMITTED ISOLATION LEVEL
    /// </summary>
    public sealed class ReadCommitted(IConsole iConsole) : Txn(
        iConsole,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;"))
    {
    }

    /// <summary>
    /// Transaction with READ UNCOMMITTED ISOLATION LEVEL
    /// </summary>
    public sealed class ReadUnCommitted(IConsole iConsole) : Txn(
        iConsole,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;"))
    {
    }

    /// <summary>
    /// Transaction with SERIALIZABLE ISOLATION LEVEL
    /// </summary>
    public sealed class Serializable(IConsole iConsole) : Txn(
        iConsole,
        new RawSql("SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;"))
    {
    }
}