using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class AvgOfTest
{
    [Fact]
    public void MakeSqlQueryWithoutAlias()
    {
        var expected = "AVG([Amount])";

        Assert.Equal(
            expected,
            new AvgOf(
                "[Amount]"
            ).Raw()
        );
    }
    
    [Fact]
    public void MakeSqlQueryWithAlias()
    {
        var expected = "AVG([Amount]) AS [AvgAmount]";

        Assert.Equal(
            expected,
            new AvgOf(
                "[Amount]",
                "[AvgAmount]"
            ).Raw()
        );
    }
}