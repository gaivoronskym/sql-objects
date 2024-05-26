using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class WhereTest
{
    [Fact]
    public void ActEqual()
    {
        string expected = "WHERE [Id] = 1";

        Assert.Equal(
            expected,
            new Where(
                new ExpressionOf("[Id]", 1)
            ).Raw()
        );
    }
    
    [Fact]
    public void ActGreaterThan()
    {
        string expected = "WHERE [Id] > 1";

        Assert.Equal(
            expected,
            new Where(
                new ExpressionOf("[Id]", ">", 1)
            ).Raw()
        );
    }
}