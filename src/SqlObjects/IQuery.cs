namespace SqlObjects;

public interface IQuery
{
    /// <summary>
    /// Converts to SQL listing
    /// </summary>
    /// <returns>String of SQL Query </returns>
    string Sql();
}