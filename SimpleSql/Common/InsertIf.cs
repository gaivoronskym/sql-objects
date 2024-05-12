﻿using SimpleSql.Interfaces;

namespace SimpleSql.Common;

public sealed class InsertIf(Func<bool> func, string table, IEnumerable<ISqlParamsOf> records, IQuery query) : IQuery
{

    #region func

    public InsertIf(Func<bool> func, string table, IEnumerable<ISqlParamsOf> records)
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

    public InsertIf(Func<bool> func, string table, ISqlParamsOf sqlparams, IQuery query)
        : this(func, table, new RecordsOf(sqlparams), query)
    {

    }

    public InsertIf(Func<bool> func, string table, ISqlParamsOf sqlparams)
        : this(func, table, new RecordsOf(sqlparams), new RawSql(""))
    {

    }

    #endregion

    #region Condition

    public InsertIf(bool condition, string table, IEnumerable<ISqlParamsOf> records)
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

    public InsertIf(bool condition, string table, ISqlParamsOf sqlparams, IQuery query)
        : this(() => condition, table, new RecordsOf(sqlparams), query)
    {

    }

    public InsertIf(bool condition, string table, ISqlParamsOf sqlparams)
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