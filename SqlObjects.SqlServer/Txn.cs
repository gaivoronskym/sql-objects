using System.Data;
using SqlObjects.Common;
using SqlObjects.Interfaces;
using Yaapii.Atoms;
using Yaapii.Atoms.Func;
using Yaapii.Atoms.List;

namespace SqlObjects.SqlServer;

/// <summary>
/// Runs SQL query in transaction
/// </summary>
/// <param name="conn"></param>
/// <param name="func"></param>
/// <param name="fallback"></param>
/// <param name="isolationLevel"></param>
public abstract class Txn<T>(IDbConnection conn, IFunc<T> func, IFunc<T> fallback, IQuery isolationLevel)
    : TxnEnvelop<T>(
        conn,
        func,
        fallback,
        isolationLevel,
        new RawSql("BEGIN TRANSACTION;"),
        new RawSql("COMMIT TRANSACTION;"),
        new RawSql("ROLLBACK TRANSACTION;"))
{
    protected override bool HasTransaction()
    {
        var openedTransactions = new Execution<int>(
            Connection,
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
    /// <param name="func"></param>
    /// <param name="fallback"></param>
    public class ReadCommitted(IDbConnection conn, IFunc<T> func, IFunc<T> fallback) : Txn<T>(
        conn,
        func,
        fallback,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;"))
    {
        public ReadCommitted(IDbConnection conn, Func<T> func, Func<T> fallback)
            : this(
                conn,
                new FuncOf<T>(func),
                new FuncOf<T>(fallback)
            )
        {

        }
    }

    /// <summary>
    /// Transaction with READ UNCOMMITTED ISOLATION LEVEL
    /// </summary>
    /// <param name="conn"></param>
    /// <param name="func"></param>
    /// <param name="fallback"></param>
    public class ReadUnCommitted(IDbConnection conn, IFunc<T> func, IFunc<T> fallback) : Txn<T>(
        conn,
        func,
        fallback,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;"))
    {
        public ReadUnCommitted(IDbConnection conn, Func<T> func, Func<T> fallback)
            : this(
                conn,
                new FuncOf<T>(func),
                new FuncOf<T>(fallback)
            )
        {
        }
    }
}