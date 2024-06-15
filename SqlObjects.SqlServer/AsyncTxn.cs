using System.Data;
using SqlObjects.Common;
using SqlObjects.Interfaces;
using Yaapii.Atoms;
using Yaapii.Atoms.Func;
using Yaapii.Atoms.List;

namespace SqlObjects.SqlServer;

/// <summary>
/// Asynchronously runs SQL query in transaction
/// </summary>
/// <param name="conn"></param>
/// <param name="func"></param>
/// <param name="fallback"></param>
/// <param name="isolationLevel"></param>
public abstract class AsyncTxn<T>(IDbConnection conn, IFunc<Task<T>> func, IFunc<T> fallback,
        IQuery isolationLevel)
    : AsyncTxnEnvelop<T>(conn,
        func,
        isolationLevel,
        new RawSql("BEGIN TRANSACTION;"),
        new RawSql("COMMIT TRANSACTION;"),
        new RawSql("ROLLBACK TRANSACTION;"))
{
    protected override async Task<bool> HasTransactionAsync()
    {
        var openedTransactions = await new AsyncExecution<int>(
            Conn,
            new Select(
                new ListOf<IQuery>(
                    new RawSql("COUNT(*)")
                ),
                "sys.sysprocesses",
                new Where("open_tran", true)
            )
        ).InvokeAsync();

        return openedTransactions > 0;
    }

    /// <summary>
    /// Transaction with READ COMMITTED ISOLATION LEVEL
    /// </summary>
    /// <param name="conn"></param>
    /// <param name="func"></param>
    /// <param name="fallback"></param>
    public sealed class ReadCommitted(IDbConnection conn, IFunc<Task<T>> func, IFunc<T> fallback) : AsyncTxn<T>(
        conn,
        func,
        fallback,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;"))
    {
        public ReadCommitted(IDbConnection conn, Func<Task<T>> func, Func<T> fallback)
            : this(
                conn,
                new FuncOf<Task<T>>(func),
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
    public sealed class ReadUnCommitted(IDbConnection conn, IFunc<Task<T>> func, IFunc<T> fallback) : AsyncTxn<T>(
        conn,
        func,
        fallback,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;"))
    {
        public ReadUnCommitted(IDbConnection conn, Func<Task<T>> func, Func<T> fallback)
            : this(
                conn,
                new FuncOf<Task<T>>(func),
                new FuncOf<T>(fallback)
            )
        {
        }
    }

    /// <summary>
    /// Transaction with SERIALIZABLE ISOLATION LEVEL
    /// </summary>
    /// <param name="conn"></param>
    /// <param name="func"></param>
    /// <param name="fallback"></param>
    public sealed class Serializable(IDbConnection conn, IFunc<Task<T>> func, IFunc<T> fallback) : AsyncTxn<T>(
        conn,
        func,
        fallback,
        new RawSql("SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;"))
    {
        public Serializable(IDbConnection conn, Func<Task<T>> func, Func<T> fallback)
            : this(
                conn,
                new FuncOf<Task<T>>(func),
                new FuncOf<T>(fallback)
            )
        {
        }
    }
}