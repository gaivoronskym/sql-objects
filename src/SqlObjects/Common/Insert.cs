using SqlObjects.Text;
using Yaapii.Atoms;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Text;

namespace SqlObjects.Common;

/// <summary>
/// Insert Into [Table_Name] ([]...[]) VALUES(...)
/// </summary>
public sealed class Insert : QueryEnvelope
{
    public Insert(string table, string column, IEnumerable<long> values)
        : this(
            table,
            new Mapped<long, IRecord>(
                value => new Record(
                    new SqlParam(
                        column,
                        value
                    )
                ),
                values
            )
        )
    {
    }

    public Insert(string table, string column, IEnumerable<DateTime> values)
        : this(
            table,
            new Mapped<DateTime, IRecord>(
                value => new Record(
                    new SqlParam(
                        column,
                        value
                    )
                ),
                values
            )
        )
    {
    }

    public Insert(string table, string column, IEnumerable<string> values)
        : this(
            table,
            new Mapped<string, IRecord>(
                value => new Record(
                    new SqlParam(
                        column,
                        value
                    )
                ),
                values
            )
        )
    {
    }

    public Insert(string table, string column, IEnumerable<int> values)
        : this(
            table,
            new Mapped<int, IRecord>(
                value => new Record(
                    new SqlParam(
                        column,
                        value
                    )
                ),
                values
            )
        )
    {
    }

    public Insert(string table, IRecord record)
        : this(table, new ManyOf<IRecord>(record))
    {
    }

    public Insert(string table, IRecord record, IQuery query)
        : this(
            table,
            new Queries(
                new Records(
                    new ManyOf<IRecord>(record)
                ),
                query
            )
        )
    {
    }

    public Insert(string table, IEnumerable<IRecord> records)
        : this(
            table,
            new Queries(
                new Records(
                    records
                )
            )
        )
    {
    }

    public Insert(string table, IEnumerable<IQuery> queries)
        : base(
            new TextWithSemicolon(
                new JoinedViaEol(
                    new Joined<IText>(
                        new Single<IText>(
                            new Formatted(
                                "INSERT INTO {0}",
                                table
                            )
                        ),
                        new Mapped<IQuery, IText>(
                            query => new TextOf(query.Sql),
                            queries
                        )
                    )
                )
            )
        )
    {
    }
}