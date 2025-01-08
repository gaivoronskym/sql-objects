using System.Diagnostics;

namespace SqlObjects.Common;

/// <summary>
/// Prints SQL Query to console
/// </summary>
/// <param name="query"></param>
public class LoggingQuery(IQuery query) : IQuery
{
    public string Sql()
    {
        var sql = query.Sql();
#if DEBUG
        Debug.Print(sql);
#else 
        Console.WriteLine(sql);
#endif
        return sql;
    }
}