using SimpleSql.Interfaces;

namespace SimpleSql.Common;

/// <summary>
/// Builds INSERT query according to the condition
/// </summary>
/// <param name="func"></param>
/// <param name="table"></param>
/// <param name="records"></param>
/// <param name="query"></param>
public sealed class InsertIf(Func<bool> func, string table, IEnumerable<ISqlParams> records, IQuery query) : IQuery
{

    #region func

    public InsertIf(Func<bool> func, string table, IEnumerable<ISqlParams> records)
        : this(func, table, records, new RawSql(""))
    {

    }

    public InsertIf(Func<bool> func, string table, string column, IEnumerable<DateTime> values)
        : this(
            func,
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

    public InsertIf(Func<bool> func, string table, string column, IEnumerable<string> values)
        : this(
            func,
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

    public InsertIf(Func<bool> func, string table, string column, IEnumerable<int> values)
        : this(
            func,
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

    public InsertIf(Func<bool> func, string table, string column, IEnumerable<long> values)
        : this(
            func,
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

    public InsertIf(Func<bool> func, string table, ISqlParams sqlparams, IQuery query)
        : this(func, table, new RecordsOf(sqlparams), query)
    {

    }

    public InsertIf(Func<bool> func, string table, ISqlParams sqlparams)
        : this(func, table, new RecordsOf(sqlparams), new RawSql(""))
    {

    }

    #endregion

    #region Condition

    public InsertIf(bool condition, string table, IEnumerable<ISqlParams> records)
        : this(() => condition, table, records, new RawSql(""))
    {

    }

    public InsertIf(bool condition, string table, string column, IEnumerable<DateTime> values)
        : this(
            condition,
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

    public InsertIf(bool condition, string table, string column, IEnumerable<string> values)
        : this(
            condition,
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

    public InsertIf(bool condition, string table, string column, IEnumerable<int> values)
        : this(
            condition,
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

    public InsertIf(bool condition, string table, string column, IEnumerable<long> values)
        : this(
            condition,
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

    public InsertIf(bool condition, string table, ISqlParams sqlparams, IQuery query)
        : this(() => condition, table, new RecordsOf(sqlparams), query)
    {

    }

    public InsertIf(bool condition, string table, ISqlParams sqlparams)
        : this(() => condition, table, new RecordsOf(sqlparams), new RawSql(""))
    {

    }

    #endregion

    public string Raw()
    {
        return new QueryIf(
            func,
            new Insert(
                table,
                records,
                query
            )
        ).Raw();
    }
}