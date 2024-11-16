namespace SqlObjects.Interfaces;

public interface IStatement
{
    T Exec<T>(IQuery query);

    void Exec(IQuery query);
}