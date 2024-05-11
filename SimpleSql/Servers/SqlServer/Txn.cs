using System.Data;
using SimpleSql.Common;
using SimpleSql.Interfaces;

namespace SimpleSql.Servers.SqlServer;

public abstract class Txn(IDbConnection connection, Action action, IQuery isolationLevel)
    : TxnWrap(connection,
    action,
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
                new Queries(
                    new RawSql("COUNT(*)")
                ),
                new Queries(
                    new Where(
                        new Condition("open_tran", true)
                    )
                )
            )
        ).Invoke();
        
        return openedTransactions > 0;
    }
    
    public class ReadCommitted(IDbConnection connection, Action action) : Txn(connection,
        action,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;"));
    
    public class ReadUnCommitted(IDbConnection connection, Action action) : Txn(connection,
        action,
        new RawSql("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;"));
}