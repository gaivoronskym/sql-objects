using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

public sealed class Insert(string table, IEnumerable<ISqlParamsOf> records, IQuery query) : IQuery
{
    public Insert(string table, IEnumerable<ISqlParamsOf> records)
        : this(table, records, new RawSql(""))
    {

    }

    public Insert(string table, string column, IEnumerable<long> values)
        : this(
            table,
            new RecordsOf(
                values.Select(
                    value => new SqlParamsOf(
                        new SqlParam(
                            column,
                            value
                        )
                    )
                )
            )
        )
    {

    }

    public Insert(string table, string column, IEnumerable<DateTime> values)
        : this(
            table,
            new RecordsOf(
                values.Select(
                    value => new SqlParamsOf(
                        new SqlParam(
                            column,
                            value
                        )
                    )
                )
            )
        )
    {

    }

    public Insert(string table, string column, IEnumerable<string> values)
        : this(
            table,
            new RecordsOf(
                values.Select(
                    value => new SqlParamsOf(
                        new SqlParam(
                            column,
                            value
                        )
                    )
                )
            )
        )
    {

    }

    public Insert(string table, string column, IEnumerable<int> values)
        : this(
            table,
            new RecordsOf(
                values.Select(
                    value => new SqlParamsOf(
                        new SqlParam(
                            column,
                            value
                        )
                    )
                )
            )
        )
    {

    }

    public Insert(string table, ISqlParamsOf sqlparams, IQuery query)
        : this(table, new RecordsOf(sqlparams), query)
    {

    }

    public Insert(string table, ISqlParamsOf sqlparams)
        : this(table, new RecordsOf(sqlparams), new RawSql(""))
    {

    }

    public string Raw()
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

        return new Joined(
            Environment.NewLine,
            new Formatted(
                "INSERT INTO {0} ({1})",
                new TextOf(table),
                new Joined(
                    ", ",
                    records.SelectMany(r => r).Select(p => p.Key()).Distinct()
                )
            ),
            new Formatted(
                " VALUES \n {0}",
                new Joined(
                    new Formatted(
                        ",{0}",
                        Environment.NewLine
                    ).AsString(),
                    records.Select(
                        record =>
                            new Formatted(
                                "({0})",
                                new Joined(", ", record.Select(p => p.Query().Raw()))
                            ).AsString()
                    )
                )
            ),
            new TextOf(";"),
            new TextOf(query.Raw)
        ).AsString();
    }
}