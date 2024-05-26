using SqlObjects.Interfaces;

namespace SqlObjects.Sample.Schema;

public interface IDboItems : ITable
{
    string Name();

    string Cost();

    string Description();

    string Price();
}