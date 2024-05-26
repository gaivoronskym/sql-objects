using SqlObjects.Interfaces;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// Deletes data from [Table_Name]
/// </summary>
/// <param name="table"></param>
/// <param name="queries"></param>
public sealed class Delete(string table, params IQuery[] queries) : IQuery
{
    public string Raw()
    {
        return new Formatted("DELETE FROM {0}{1};",
            new TextOf(table),
            new TextIf(
                queries.Any(),
                new Formatted(
                    "\r\n{0}",
                    new Joined(Environment.NewLine, queries.Select(q => q.Raw()))
                )
            )
        ).AsString();
    }
}