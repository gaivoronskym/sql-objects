namespace SimpleSql.Sample.Interfaces;

public interface IContractors
{
    IList<IContractor> List();

    IContractor Get(long id);
}