namespace SimpleSql.Interfaces;

public interface IFetch
{
    IList<IRow> Rows();
}