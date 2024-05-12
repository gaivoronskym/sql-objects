using SimpleSql.Common;

namespace SimpleSql.Tests.Common;

public class WhereTest
{
    [Fact]
    public void ActEqual()
    {
        string expected = "WHERE [Id] = 1";

        Assert.Equal(
            expected,
            new Where(
                new Condition("[Id]", 1)
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
                new Condition("[Id]", ">", 1)
            ).Raw()
        );
    }
}