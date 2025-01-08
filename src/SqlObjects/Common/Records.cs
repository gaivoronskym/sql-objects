using SqlObjects.Text;
using Yaapii.Atoms;
using Yaapii.Atoms.List;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Common;

/// <summary>
/// List of records
/// </summary>
public sealed class Records(IEnumerable<IRecord> records) : IQuery
{
    public Records(IRecord record)
        : this(new ListOf<IRecord>(record))
    {
        
    }
    
    public string Sql()
    {
        if (!records.Any())
        {
            throw new ArgumentException("Should be at least one record to insert");
        }
        
        var countOfParams = records.First().Count();

        if (records.Any(r => r.Count() != countOfParams))
        {
            throw new ArgumentException("");
        }

        return new JoinedViaEol(
            new Formatted(
                "({0})",
                new Joined(
                    ", ",
                    records.SelectMany(r => r).Select(p => p.Name()).Distinct()
                )
            ),
            new JoinedViaEol(
                new Joined<IText>(
                    new ListOf<IText>(new TextOf("VALUES")),
                    new Joined(
                        ",\r\n",
                        new Mapped<IRecord, IText>(
                            record => new Formatted(
                                "({0})",
                                new Joined(", ", record.Select(p => p.Value().Sql()))
                            ),
                            records
                        )
                    )
                )
            )
        ).AsString();
    }
}