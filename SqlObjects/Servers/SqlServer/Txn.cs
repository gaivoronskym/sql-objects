using System.Data;
using SqlObjects.Common;
using SqlObjects.Interfaces;
using Yaapii.Atoms;
using Yaapii.Atoms.Func;
using Yaapii.Atoms.List;

namespace SqlObjects.Servers.SqlServer;

/// <summary>
/// Runs SQL query in transaction
/// </summary>
/// <param name="connection"></param>
/// <param name="func"></param>
/// <param name="fallback"></param>
/// <param name="isolationLevel"></param>
public abstract class Txn<T>(IDbConnection connection, IFunc<T> func, IFunc<T> fallback, IQuery isolationLevel)
    : TxnEnvelop<T>(connection,
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
                "sys.sysprocesses",
                new ListOf<IQuery>(
                    new RawSql("COUNT(*)")
                ),
                new Where(
                    new Expression("open_tran", true)
                )
            )
        ).Invoke();

        return openedTransactions > 0;
    }

    /// <summary>
    /// Transaction with READ COMMITTED ISOLATION LEVEL
    /// </summary>
    /// <param name="connection"></param>
    /// <param name="func"></param>
    /// <param name="fallback"></param>
    public class ReadCommitted(IDbConnection connection, IFunc<T> func, IFunc<T> fallback) : Txn<T>(connection,
        func,
        fallback,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;"))
    {
        public ReadCommitted(IDbConnection connection, Func<T> func, Func<T> fallback)
            : this(
                connection,
                new FuncOf<T>(func),
                new FuncOf<T>(fallback)
            )
        {

        }
    }

    /// <summary>
    /// Transaction with READ UNCOMMITTED ISOLATION LEVEL
    /// </summary>
    /// <param name="connection"></param>
    /// <param name="func"></param>
    /// <param name="fallback"></param>
    public class ReadUnCommitted(IDbConnection connection, IFunc<T> func, IFunc<T> fallback) : Txn<T>(connection,
        func,
        fallback,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;"))
    {
        public ReadUnCommitted(IDbConnection connection, Func<T> func, Func<T> fallback)
            : this(
                connection,
                new FuncOf<T>(func),
                new FuncOf<T>(fallback)
            )
        {

        }
    }
}