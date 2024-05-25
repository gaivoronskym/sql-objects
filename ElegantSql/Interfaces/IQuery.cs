namespace ElegantSql.Interfaces;

public interface IQuery
{
    /// <summary>
    /// Converts to SQL listing
    /// </summary>
    /// <returns>String of SQL Query </returns>
    string Raw();

    public sealed class None : IQuery
    {
        public string Raw()
        {
            return string.Empty;
        }
    }
}