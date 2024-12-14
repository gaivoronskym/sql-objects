using SqlObjects.Interfaces;

namespace SqlObjects;

public interface IConsole
{
    IEnumerable<IRow> Exec(IQuery query);
}