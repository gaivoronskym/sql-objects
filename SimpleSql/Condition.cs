using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SimpleSql;

public sealed class Condition : IQuery
{
    private readonly IQuery _field;
    private readonly string _operation;
    private readonly IQuery _value;

    public Condition(IQuery field, string operation, IQuery value)
    {
        _field = field;
        _operation = operation;
        _value = value;
    }

    public Condition(IQuery field, IQuery value)
        : this(field, "=", value)
    {

    }

    public Condition(string field, string operation, IQuery value)
        : this(new RawSql(field), operation, value)
    {
        
    }
    
    public Condition(string field, IQuery value)
        : this(new RawSql(field), "=", value)
    {

    }

    public string Raw()
    {
        return new Formatted(
            "{0} {1} {2}",
            true,
            new TextOf(_field.Raw),
            new TextOf(_operation),
            new TextOf(_value.Raw())
        ).AsString();
    }
}
