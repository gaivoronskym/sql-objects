using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SqlObjects.Text;

public sealed class EolWithText : IText
{
    private readonly Func<string> func;

    public EolWithText(IText text)
        : this(text.AsString)
    {
    }

    public EolWithText(string text)
        : this(() => text)
    {
    }

    public EolWithText(IQuery query)
        : this(query.Sql)
    {
    }

    private EolWithText(Func<string> func)
    {
        this.func = func;
    }

    public string AsString()
    {
        return new Formatted(
            "\r\n{0}",
            func()
        ).AsString();
    }
}