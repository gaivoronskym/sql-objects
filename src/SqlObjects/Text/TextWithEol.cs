using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SqlObjects.Text;

public sealed class TextWithEol : IText
{
    private readonly Func<string> func;

    public TextWithEol(IText text)
        : this(text.AsString)
    {
    }

    public TextWithEol(string text)
        : this(() => text)
    {
    }

    public TextWithEol(IQuery query)
        : this(query.Sql)
    {
    }

    private TextWithEol(Func<string> func)
    {
        this.func = func;
    }

    public string AsString()
    {
        return new Formatted(
            "{0}\r\n",
            func()
        ).AsString();
    }
}