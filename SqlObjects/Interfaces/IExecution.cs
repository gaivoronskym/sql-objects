namespace SqlObjects.Interfaces;

public interface IExecution<out T>
{
    T Invoke();
}

public interface IExecution
{
    void Invoke();
}