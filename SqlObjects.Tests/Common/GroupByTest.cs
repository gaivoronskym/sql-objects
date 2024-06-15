using SqlObjects.SqlServer;

namespace SqlObjects.Tests.Common;

public class GroupByTest
{
    [Fact]
    public void Act()
    {
        string expected = "GROUP BY [Id]";

        Assert.Equal(
            expected,
            new GroupBy("[Id]").Raw()
        );
    }
}