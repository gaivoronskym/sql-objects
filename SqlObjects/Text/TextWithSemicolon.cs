using SqlObjects.Interfaces;
using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SqlObjects.Text;

public sealed class TextWithSemicolon : IText
{
    private readonly Func<string> func;
    
    public TextWithSemicolon(IText text)
        : this(text.AsString)
    {
    }

    public TextWithSemicolon(string text)
        : this(() => text)
    {
    }

    public TextWithSemicolon(IQuery query)
        : this(query.Raw)
    {
    }
    
    private TextWithSemicolon(Func<string> func)
    {
        this.func = func;
    }
    
    public string AsString()
    {
        return new Formatted(
            "{0};",
            func()
        ).AsString();
    }
}