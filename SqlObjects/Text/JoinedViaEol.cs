using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace SqlObjects.Text;

public sealed class JoinedViaEol : TextEnvelope
{
    public JoinedViaEol(IEnumerable<IText> texts)
        : this(
            new Joined(
                "\r\n",
                texts
            ),
            false
        )
    {
    }
    
    public JoinedViaEol(params IText[] texts)
        : this(
            new Joined(
                "\r\n",
                texts
            ),
            false
        )
    {
    }
    
    public JoinedViaEol(IEnumerable<string> str)
        : this(
            new Joined(
                "\r\n",
                str
            ),
            false
        )
    {
    }

    public JoinedViaEol(params string[] str)
        : this(
            new Joined(
                "\r\n",
                str
            ),
            false
        )
    {
    }

    public JoinedViaEol(IText text, bool live) : base(text, live)
    {
    }
}