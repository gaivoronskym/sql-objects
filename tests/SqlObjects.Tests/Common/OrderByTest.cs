using SqlObjects.Common;

namespace SqlObjects.Tests.Common;

public class OrderByTest
{
    [Fact]
    public void MakeOrderByAsc()
    {
        string expected = "ORDER BY [Id] ASC";

        Assert.Equal(
            expected,
            new OrderByAsc("[Id]").Sql()
        );
    }
    
    [Fact]
    public void MakeOrderByDesc()
    {
        string expected = "ORDER BY [Id] DESC";

        Assert.Equal(
            expected,
            new OrderByDesc("[Id]").Sql()
        );
    }
}