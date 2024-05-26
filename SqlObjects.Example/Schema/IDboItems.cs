using SqlObjects.Interfaces;

namespace ElegantSql.Sample.Schema;

public interface IDboItems : ITable
{
    string Name();

    string Cost();

    string Description();

    string Price();
}