namespace SqlObjects.Interfaces;

public interface IExecution<T>
{
    T Invoke();
}