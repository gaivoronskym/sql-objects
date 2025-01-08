using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// INNER JOIN query
/// </summary>
/// <param name="table">name of table</param>
/// <param name="first">first expression</param>
/// <param name="second">second expression</param>
/// <param name="query">sub query</param>
/// <param name="operation">boolean operation</param>
public sealed class InnerJoin(string table, string first, string second, IQuery query, string operation = "=") : Join(table, first, second, "INNER", query, operation)
{
    public InnerJoin(string table, string first, string second, string operation = "=")
        : this(table, first, second, new QueryOf(new Blank()), operation)
    {
        
    }
}