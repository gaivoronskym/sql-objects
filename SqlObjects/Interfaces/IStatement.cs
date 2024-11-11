namespace SqlObjects.Interfaces;

public interface IStatement<out T>
{
    T Exec();
}

public interface IStatement
{
    void Exec();
}