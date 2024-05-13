using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

/// <summary>
/// LEFT JOIN query
/// </summary>
/// <param name="table">name of table</param>
/// <param name="first">first expression</param>
/// <param name="second">second expression</param>
/// <param name="query">sub query</param>
/// <param name="operation">boolean operation</param>
public sealed class LeftJoin(string table, string first, string second, IQuery query, string operation = "=") : Join(table, first, second, "LEFT", query, operation)
{
    public LeftJoin(string table, string first, string second, string operation = "=")
        : this(table, first, second, new RawSql(new Blank()), operation)
    {
        
    }
}