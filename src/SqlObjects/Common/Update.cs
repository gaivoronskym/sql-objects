﻿using SqlObjects.Text;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;
using Yaapii.Atoms.Scalar;
using Yaapii.Atoms.Text;
using Joined = Yaapii.Atoms.Text.Joined;

namespace SqlObjects.Common;

/// <summary>
/// UPDATE query
/// </summary>
/// <param name="from">name of table</param>
/// <param name="sqlParams">columns and values</param>
/// <param name="queries">expressions</param>
public sealed class Update(string from, IEnumerable<ISqlParam> sqlParams, IEnumerable<IQuery> queries)
    : IQuery
{

    public Update(string from, ISqlParam param, IQuery query)
        : this(from, new ManyOf<ISqlParam>(param), new Queries(query))
    {

    }

    public Update(string from, IEnumerable<ISqlParam> sqlParams, IQuery query)
        : this(from, sqlParams, new Queries(query))
    {
        
    }
    
    public Update(string from, IEnumerable<ISqlParam> sqlParams)
        : this(from, sqlParams, new ListOf<IQuery>())
    {
    }

    public Update(string from, ISqlParam param)
        : this(from, new ManyOf<ISqlParam>(param), new ListOf<IQuery>())
    {
    }

    public string Sql()
    {
        return new Formatted(
            "UPDATE {0} SET {1}{2};",
            new TextOf(from),
            new Joined(
                ",",
                sqlParams.Select(p => new Formatted("{0} = {1}", p.Name(), p.Value().Sql()))
            ),
            new TextIf(
                new ScalarOf<bool>(queries.Any),
                new EolWithText(
                    new Joined(
                        Environment.NewLine,
                        queries.Select(q => q.Sql())
                    )
                )
            )
        ).AsString();
    }
}