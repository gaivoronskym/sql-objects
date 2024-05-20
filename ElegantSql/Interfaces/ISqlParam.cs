namespace ElegantSql.Interfaces;

public interface ISqlParam
{
    string Key();

    IQuery Query();
}