﻿namespace SqlObjects.Interfaces;

public interface IFetch
{
    /// <summary>
    /// Fetching records from database
    /// </summary>
    /// <returns>rows</returns>
    IList<IRow> Rows(IQuery query);
}