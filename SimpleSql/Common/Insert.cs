using SimpleSql.Interfaces;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

/// <summary>
/// Insert Into [Table_Name] ([]...[]) VALUES(...)
/// </summary>
/// <param name="table"></param>
/// <param name="records"></param>
/// <param name="query"></param>
public sealed class Insert(string table, IEnumerable<ISqlParams> records, IQuery query) : IQuery
{
    public Insert(string table, IEnumerable<ISqlParams> records)
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

    public Insert(string table, ISqlParams sqlParams, IQuery query)
        : this(table, new RecordsOf(sqlParams), query)
    {

    }

    public Insert(string table, ISqlParams sqlParams)
        : this(table, new RecordsOf(sqlParams), new RawSql(""))
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

        var queryRaw = query.Raw();

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
                "VALUES\r\n{0};{1}",
                //records
                new Joined(
                    new Formatted(
                        ",{0}",
                        Environment.NewLine
                    ).AsString(),
                    records.Select(
                        record => new Formatted(
                            "({0})",
                            new Joined(", ", record.Select(p => p.Query().Raw()))
                        ).AsString()
                    )
                ),
                //additional query
                new TextIf(
                    !string.IsNullOrEmpty(queryRaw),
                    new Formatted(
                        "{0}{1}",
                        Environment.NewLine,
                        queryRaw
                    )
                )
            )
        ).AsString();
    }
}