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
            new Expression("[Id]", 1).Raw()
        );
    }
    
    [Fact]
    public void ActGreaterThan()
    {
        string expected = "[Id] > 1";

        Assert.Equal(
            expected,
            new Expression("[Id]", ">", 1).Raw()
        );
    }
}