namespace SqlObjects;

public interface ISqlParam
{
    string Name();

    IQuery Value();
}