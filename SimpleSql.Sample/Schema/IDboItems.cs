using SimpleSql.Interfaces;
using SimpleSql.Schema;

namespace SimpleSql.Sample.Schema;

public interface IDboItems : ITable
{
    string Name();

    string Cost();

    string Description();

    string Price();
}