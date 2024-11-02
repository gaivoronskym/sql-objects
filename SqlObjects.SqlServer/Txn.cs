using System.Data;
using SqlObjects.Common;
using SqlObjects.Interfaces;
using Yaapii.Atoms.List;

namespace SqlObjects.SqlServer;

/// <summary>
/// Runs SQL query in transaction
/// </summary>
/// <param name="conn"></param>
/// <param name="isolationLevel"></param>
public abstract class Txn<T>(IDbConnection conn, IQuery isolationLevel)
    : TxnEnvelop<T>(
        conn,
        isolationLevel,
        new RawSql("BEGIN TRANSACTION;"),
        new RawSql("COMMIT TRANSACTION;"),
        new RawSql("ROLLBACK TRANSACTION;"))
{
    protected override bool HasTransaction()
    {
        var openedTransactions = new Execution<int>(
            Conn,
            new Select(
                new ListOf<IQuery>(
                    new RawSql("COUNT(*)")
                ),
                "sys.sysprocesses",
                new Where("open_tran", true)
            )
        ).Invoke();

        return openedTransactions > 0;
    }

    /// <summary>
    /// Transaction with READ COMMITTED ISOLATION LEVEL
    /// </summary>
    /// <param name="conn"></param>
    public sealed class ReadCommitted(IDbConnection conn) : Txn<T>(
        conn,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;"))
    {
    }

    /// <summary>
    /// Transaction with READ UNCOMMITTED ISOLATION LEVEL
    /// </summary>
    /// <param name="conn"></param>
    public sealed class ReadUnCommitted(IDbConnection conn) : Txn<T>(
        conn,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;"))
    {
    }

    /// <summary>
    /// Transaction with SERIALIZABLE ISOLATION LEVEL
    /// </summary>
    /// <param name="conn"></param>
    public sealed class Serializable(IDbConnection conn) : Txn<T>(
        conn,
        new RawSql("SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;"))
    {
    }
}