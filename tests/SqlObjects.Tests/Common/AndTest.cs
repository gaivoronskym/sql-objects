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
                new Condition("[Id]", 1)
            ).Sql()
        );
    }
    
    [Fact]
    public void ActGreaterThan()
    {
        string expected = "AND [Id] > 1";

        Assert.Equal(
            expected,
            new And(
                new Condition("[Id]", ">", 1)
            ).Sql()
        );
    }
}