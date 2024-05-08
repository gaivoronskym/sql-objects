using Yaapii.Atoms.Text;

namespace SimpleSql;

public sealed class LeftJoin(string table, string first, string second, IQuery query, string operation = "=") : Join(table, first, second, "LEFT", query, operation)
{
    public LeftJoin(string table, string first, string second, string operation = "=")
        : this(table, first, second, new RawSql(new Blank()), operation)
    {
        
    }
}