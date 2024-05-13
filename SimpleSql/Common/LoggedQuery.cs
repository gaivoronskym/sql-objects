using System.Diagnostics;
using SimpleSql.Interfaces;

namespace SimpleSql.Common;

/// <summary>
/// Prints SQL Query to console
/// </summary>
/// <param name="query"></param>
public class LoggedQuery(IQuery query) : IQuery
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