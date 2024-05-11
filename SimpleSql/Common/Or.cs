using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class Or(IQuery query) : IQuery
{
    public string Raw()
    {
        return new Formatted(
            "OR {0}",
            query.Raw()
        ).AsString();
    }
}