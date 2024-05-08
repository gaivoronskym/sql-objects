using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class Insert(string table, IEnumerable<ISqlParam> sqlparams, IQuery query) : IQuery
{

    public Insert(string table, IEnumerable<ISqlParam> sqlparams)
        : this(table, sqlparams, new RawSql(""))
    {
        
    }
    
    public string Raw()
    {
        return new Joined(
            Environment.NewLine,
            new Formatted("INSERT INTO {0} ({1})", new TextOf(table), new Joined(", ", sqlparams.Select(s => s.Key()))),
            new Formatted(" VALUES ({0})", new Joined(", ", sqlparams.Select(s => s.Query().Raw()))),
            new TextOf(";"),
            new TextOf(query.Raw)
        ).AsString();
    }
}