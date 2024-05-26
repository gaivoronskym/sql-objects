using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class AndTest
{
    [Fact]
    public void ActEqual()
    {
        string expected = "AND [Id] = 1";

        Assert.Equal(
            expected,
            new And(
                new ExpressionOf("[Id]", 1)
            ).Raw()
        );
    }
    
    [Fact]
    public void ActGreaterThan()
    {
        string expected = "AND [Id] > 1";

        Assert.Equal(
            expected,
            new And(
                new ExpressionOf("[Id]", ">", 1)
            ).Raw()
        );
    }
}