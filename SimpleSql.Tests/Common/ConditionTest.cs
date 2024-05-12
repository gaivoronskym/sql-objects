using SimpleSql.Common;

namespace SimpleSql.Tests.Common;

public class ConditionTest
{
    [Fact]
    public void ActEqual()
    {
        string expected = "[Id] = 1";

        Assert.Equal(
            expected,
            new Condition("[Id]", 1).Raw()
        );
    }
    
    [Fact]
    public void ActGreaterThan()
    {
        string expected = "[Id] > 1";

        Assert.Equal(
            expected,
            new Condition("[Id]", ">", 1).Raw()
        );
    }
}