using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class SumOfTest
{
    [Fact]
    public void MakeSqlQueryWithoutAlias()
    {
        var expected = "SUM([Amount])";

        Assert.Equal(
            expected,
            new Sum(
                "[Amount]"
            ).Sql()
        );
    }
    
    [Fact]
    public void MakeSqlQueryWithAlias()
    {
        var expected = "SUM([Amount]) AS [Total]";

        Assert.Equal(
            expected,
            new Sum(
                "[Amount]",
                "[Total]"
            ).Sql()
        );
    }
}