using System.Diagnostics;
using SqlObjects.Interfaces;

namespace SqlObjects.Common;

/// <summary>
/// Prints SQL Query to console
/// </summary>
/// <param name="query"></param>
public class LoggingQuery(IQuery query) : IQuery
{
    public string Raw()
    {
        var sql = query.Raw();
#if DEBUG
        Debug.Print(sql);
#else 
        Console.WriteLine(sql);
#endif
        return sql;
    }
}