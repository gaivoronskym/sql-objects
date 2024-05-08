namespace SimpleSql.Interfaces;

public interface ISyncFetch
{
    IList<IRow> Rows();
}