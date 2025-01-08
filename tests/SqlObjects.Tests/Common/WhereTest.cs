using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class WhereTest
{
    [Fact]
    public void ActEqual()
    {
        string expected = "WHERE\r\n[Id] = 1";

        Assert.Equal(
            expected,
            new Where(
                new Condition("[Id]", 1)
            ).Sql()
        );
    }
    
    [Fact]
    public void ActGreaterThan()
    {
        string expected = "WHERE\r\n[Id] > 1";

        Assert.Equal(
            expected,
            new Where(
                new Condition("[Id]", ">", 1)
            ).Sql()
        );
    }
}