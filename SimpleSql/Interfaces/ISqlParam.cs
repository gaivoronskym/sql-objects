namespace SimpleSql.Interfaces;

public interface ISqlParam
{
    string Key();

    IQuery Query();
}