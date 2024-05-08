using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class InnerJoin(string table, string first, string second, IQuery query, string operation = "=") : Join(table, first, second, "INNER", query, operation)
{
    public InnerJoin(string table, string first, string second, string operation = "=")
        : this(table, first, second, new RawSql(new Blank()), operation)
    {
        
    }
}