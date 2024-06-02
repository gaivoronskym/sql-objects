using SqlObjects.Interfaces;
using Yaapii.Atoms;
using Yaapii.Atoms.List;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Common;

/// <summary>
/// Insert Into [Table_Name] ([]...[]) VALUES(...)
/// </summary>
/// <param name="table"></param>
public sealed class Insert(string table, IEnumerable<IQuery> queries) : IQuery
{
    public Insert(string table, string column, IEnumerable<long> values)
        : this(
            table,
            values.Select(
                value => new Record(
                    new SqlParam(
                        column,
                        value
                    )
                )
            )
        )
    {
    }

    public Insert(string table, string column, IEnumerable<DateTime> values)
        : this(
            table,
            values.Select(
                value => new Record(
                    new SqlParam(
                        column,
                        value
                    )
                )
            )
        )
    {
    }

    public Insert(string table, string column, IEnumerable<string> values)
        : this(
            table,
            values.Select(
                value => new Record(
                    new SqlParam(
                        column,
                        value
                    )
                )
            )
        )
    {
    }

    public Insert(string table, string column, IEnumerable<int> values)
        : this(
            table,
            values.Select(
                value => new Record(
                    new SqlParam(
                        column,
                        value
                    )
                )
            )
        )
    {
    }

    public Insert(string table, IRecord record)
        : this(table, new ListOf<IRecord>(record))
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
    
    public string Raw()
    {
        return new Formatted(
            "{0};",
            new Joined(
                "\r\n",
                new Joined<IText>(
                    new ListOf<IText>(
                        new Formatted(
                            "INSERT INTO {0}",
                            table
                        )
                    ),
                    new Mapped<IQuery, IText>(
                        query => new TextOf(query.Raw),
                        queries
                    )
                )
            )
        ).AsString();
    }
}