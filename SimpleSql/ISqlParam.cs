namespace SimpleSql;

public interface ISqlParam
{
    string Key();

    IQuery Query();
}