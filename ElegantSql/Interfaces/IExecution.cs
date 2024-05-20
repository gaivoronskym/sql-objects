namespace ElegantSql.Interfaces;

public interface IExecution<T>
{
    T Invoke();
}