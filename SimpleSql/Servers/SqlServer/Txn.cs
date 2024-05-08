using System.Data;
using SimpleSql.Common;
using SimpleSql.Interfaces;

namespace SimpleSql.Servers.SqlServer;

public abstract class Txn : TxnWrap
{
    protected Txn(IDbConnection connection, Action action, IQuery isolationLevel) 
        : base(
            connection,
            action,
            isolationLevel,
            new RawSql("BEGIN TRANSACTION;"),
            new RawSql("COMMIT TRANSACTION;"),
            new RawSql("ROLLBACK TRANSACTION;"))
    {
    }

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
    
    public class ReadCommitted : Txn
    {
        public ReadCommitted(IDbConnection connection, Action action) 
            : base(
                connection,
                action,
                new RawSql("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;")
            )
        {
        }
    }
    
    public class ReadUnCommitted : Txn
    {
        public ReadUnCommitted(IDbConnection connection, Action action) 
            : base(
                connection,
                action,
                new RawSql("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;"))
        {
        }
    }
}