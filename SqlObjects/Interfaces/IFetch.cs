namespace SqlObjects.Interfaces;

public interface IFetch
{
    IRow Row(IQuery query);

    /// <summary>
    /// Fetching records from database
    /// </summary>
    /// <returns>rows</returns>
    IList<IRow> Rows(IQuery query);
}