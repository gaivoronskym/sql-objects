using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class ConditionTest
{
    [Fact]
    public void ActEqual()
    {
        string expected = "[Id] = 1";

        Assert.Equal(
            expected,
            new Condition("[Id]", 1).Sql()
        );
    }
    
    [Fact]
    public void ActGreaterThan()
    {
        string expected = "[Id] > 1";

        Assert.Equal(
            expected,
            new Condition("[Id]", ">", 1).Sql()
        );
    }
}