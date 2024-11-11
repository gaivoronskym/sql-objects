﻿using System.Data;
using SqlObjects.Interfaces;

namespace SqlObjects.Common;

/// <summary>
/// Transaction wrapper
/// </summary>
/// <param name="conn">database connection</param>
/// <param name="isolationLevel"></param>
/// <param name="begin"></param>
/// <param name="commit"></param>
/// <param name="rollback"></param>
public abstract class TxnEnvelop<T>(IDbConnection conn, IQuery isolationLevel, IQuery begin, IQuery commit, IQuery rollback)
    : ITxn<T>
{
    protected readonly IDbConnection Conn = conn;

    public T Invoke(Func<T> func)
    {
        try
        {
            Begin();
            var res = func.Invoke();
            Commit();
            return res;
        }
        catch (Exception ex)
        {
            Rollback();
            Console.WriteLine(ex);
            throw;
        }
    }

    protected abstract bool HasTransaction();

    private void Begin()
    {
        new Statement(
            Conn,
            new QueryOf(
                new Queries(
                    isolationLevel,
                    begin
                )
            )
        ).Exec();
    }
    
    private void Commit()
    {
        if (HasTransaction())
        {
            new Statement(
                Conn,
                commit
            ).Exec();
        }
    }
    
    private void Rollback()
    {
        if (HasTransaction())
        {
            new Statement(
                Conn,
                rollback
            ).Exec();
        }
    }
}