using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class OrTest
{
    [Fact]
    public void ActEqual()
    {
        string expected = "OR [Id] = 1";

        Assert.Equal(
            expected,
            new Or(
                new Condition("[Id]", 1)
            ).Sql()
        );
    }
    
    [Fact]
    public void ActGreaterThan()
    {
        string expected = "OR [Id] > 1";

        Assert.Equal(
            expected,
            new Or(
                new Condition("[Id]", ">", 1)
            ).Sql()
        );
    }
}