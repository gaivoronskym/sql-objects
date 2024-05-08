using SimpleSql.Sample.Interfaces;

namespace SimpleSql.Sample;

public class ConstContractor : IContractor
{
    private readonly IContractor _origin;
    private readonly string _name;

    public ConstContractor(IContractor origin, string name)
    {
        _origin = origin;
        _name = name;
    }

    public long Id()
    {
        return _origin.Id();
    }

    public string Name()
    {
        return _name;
    }
}