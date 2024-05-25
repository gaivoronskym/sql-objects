﻿using System.Data;
using ElegantSql.Interfaces;

namespace ElegantSql.Common;

/// <summary>
/// Transaction wrapper
/// </summary>
/// <param name="connection">database connection</param>
/// <param name="action">action to execute</param>
/// <param name="isolationLevel"></param>
/// <param name="begin"></param>
/// <param name="commit"></param>
/// <param name="rollback"></param>
public abstract class TxnWrap(IDbConnection connection, Action action, IQuery isolationLevel, IQuery begin,
        IQuery commit, IQuery rollback)
    : ITxn
{
    protected readonly IDbConnection Connection = connection;

    public void Invoke()
    {
        try
        {
            Begin();
        
            action();
        
            Commit();
        }
        catch (Exception e)
        {
            Rollback();
            Console.WriteLine(e);
        }
    }

    protected abstract bool HasTransaction();

    private void Begin()
    {
        new Execution<int>(
            Connection,
            isolationLevel
        ).Invoke();
        
        new Execution<int>(
            Connection,
            begin
        ).Invoke();
    }
    
    private void Commit()
    {
        if (HasTransaction())
        {
            new Execution<int>(
                Connection,
                commit
            ).Invoke();
        }
    }
    
    private void Rollback()
    {
        if (HasTransaction())
        {
            new Execution<int>(
                Connection,
                rollback
            ).Invoke();
        }
    }
}