//using System.Data;
//using Dapper;
//using SqlObjects.Interfaces;

//namespace SqlObjects;

///// <summary>
///// Returns records from database
///// </summary>
///// <param name="conn">database connection</param>
///// <param name="query">SQL query</param>
///// <param name="timeout">command timeout</param>
//public sealed class Fetch : IFetch
//{
//    private readonly IDbConnection conn;
//    private readonly IQuery query;
//    private readonly int timeout;

//    public Fetch(IDbConnection conn, IQuery query)
//        : this(conn, query, 30)
//    {
        
//    }

//    public Fetch(IDbConnection conn, IQuery query, int timeout)
//    {
//        this.conn = conn;
//        this.query = query;
//        this.timeout = timeout;
//    }

//    public IList<IRow> Rows()
//    {
//        var res = conn.Query(
//            sql: query.Raw(),
//            commandTimeout: timeout
//        ).Cast<IDictionary<string, object>>();

//        IList<IRow> rows = new List<IRow>();
//        foreach (var row in res)
//        {
//            rows.Add(new Row(row));
//        }
        
//        return rows;
//    }
//}