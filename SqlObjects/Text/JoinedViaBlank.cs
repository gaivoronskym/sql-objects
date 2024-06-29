using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SqlObjects.Text;

public sealed class JoinedViaBlank : TextEnvelope
{
    public JoinedViaBlank(IEnumerable<IText> texts)
        : this(
            new Joined(
                "",
                texts
            ),
            false
        )
    {
    }
    
    public JoinedViaBlank(params IText[] texts)
        : this(
            new Joined(
                "",
                texts
            ),
            false
        )
    {
    }
    
    public JoinedViaBlank(IEnumerable<string> str)
        : this(
            new Joined(
                "",
                str
            ),
            false
        )
    {
    }

    public JoinedViaBlank(params string[] str)
        : this(
            new Joined(
                "",
                str
            ),
            false
        )
    {
    }
    
    private JoinedViaBlank(IText text, bool live) : base(text, live)
    {
    }
}