using System.Text.RegularExpressions;
using SimpleSql.Servers.SqlServer;

namespace SimpleSql.Tests.Common;

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