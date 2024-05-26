namespace SqlObjects.Interfaces;

public interface ISqlParam
{
    string Key();

    IQuery Query();
}