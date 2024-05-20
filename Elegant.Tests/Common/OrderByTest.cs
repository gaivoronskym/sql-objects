using ElegantSql.Servers.SqlServer;

namespace Elegant.Tests.Common;

public class OrderByTest
{
    [Fact]
    public void MakeOrderByAsc()
    {
        string expected = "ORDER BY [Id] ASC";

        Assert.Equal(
            expected,
            new OrderByAsc("[Id]").Raw()
        );
    }
    
    [Fact]
    public void MakeOrderByDesc()
    {
        string expected = "ORDER BY [Id] DESC";

        Assert.Equal(
            expected,
            new OrderByDesc("[Id]").Raw()
        );
    }
}