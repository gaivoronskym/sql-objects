using ElegantSql.Common;

namespace Elegant.Tests.Common;

public class SumOfTest
{
    [Fact]
    public void MakeSqlQueryWithoutAlias()
    {
        var expected = "SUM([Amount])";

        Assert.Equal(
            expected,
            new SumOf(
                "[Amount]"
            ).Raw()
        );
    }
    
    [Fact]
    public void MakeSqlQueryWithAlias()
    {
        var expected = "SUM([Amount]) AS [Total]";

        Assert.Equal(
            expected,
            new SumOf(
                "[Amount]",
                "[Total]"
            ).Raw()
        );
    }
}