using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SimpleSql;

public class Condition : IQuery
{
    private readonly string _field;
    private readonly string _operation;
    private readonly IText _value;

    public Condition(string field, string operation, IText value)
    {
        _field = field;
        _operation = operation;
        _value = value;
    }

    public Condition(string field, IText value)
        : this(field, "=", value)
    {

    }

    public string Raw()
    {
        return new Formatted(
            "{0} {1} {2}",
            true,
            new TextOf(_field),
            new TextOf(_operation),
            _value
        ).AsString();
    }
}
