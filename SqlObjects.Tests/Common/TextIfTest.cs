using Yaapii.Atoms.Text;

namespace SqlObjects.Tests.Common;

public class TextIfTest
{
    [Fact]
    public void TestFirstValue()
    {
        var literal = "Hello, world";

        Assert.Equal(
            "Hello, world",
            new TextIf(
                true,
                new TextOf(literal)
            ).AsString()
        );
    }
    
    [Fact]
    public void TestSecondValue()
    {
        var literal = "Hello, world";

        Assert.Equal(
            new Blank().AsString(),
            new TextIf(
                literal.Contains("true"),
                new TextOf(literal)
            ).AsString()
        );
    }
}