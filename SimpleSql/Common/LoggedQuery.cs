using System.Diagnostics;
using SimpleSql.Interfaces;

namespace SimpleSql.Common;

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